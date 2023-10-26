using MagicBalanceConfigurator.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseGenerator
    {
        protected const int MaxItems = 9999;
        protected const int MaxModsCount = 10;
        protected const int MaxModsTextCount = 5;
        protected const double MaxModPower = 10;
        protected const double MinModPower = 0.1;

        private int _seed;
        public int Seed
        {
            get => _seed;
            set
            {
                if (_seed != value)
                {
                    Rand = new Random(value);
                    _seed = Rand.Next();
                }
            }
        }

        public bool IsActive { get; set; }
        public string GeneratorSchemaName { get; private set; }

        private int _itemsCount;
        public int ItemsCount
        {
            get => _itemsCount;
            set
            {
                if (value < 10) value = 10;
                if (value > MaxItems) value = MaxItems;
                _itemsCount = value;
            }
        }

        private int _itemsPrice;
        public int ItemsPrice
        {
            get => _itemsPrice;
            set
            {
                if (value < 1) value = 1;
                if (value > 99999) value = 99999;
                _itemsPrice = value;
            }
        }

        private double _modPower;
        public double ModPower
        {
            get => _modPower;
            set
            {
                if (value < MinModPower) value = MinModPower;
                if (value > MaxModPower) value = MaxModPower;
                _modPower = value;
            }
        }

        private int _modsCountMin;
        public int ModsCountMin
        {
            get => _modsCountMin;
            set
            {
                if (value < 1) value = 1;
                if (value > MaxModsCount) value = MaxModsCount;
                if (value > ModsCountMax) value = ModsCountMax; 
                _modsCountMin = value;
            }
        }

        private int _modsCountMax;
        public int ModsCountMax
        {
            get => _modsCountMax;
            set
            {
                if (value < 1) value = 1;
                if (value > MaxModsCount) value = MaxModsCount;
                if (value < ModsCountMin) value = ModsCountMin;
                _modsCountMax = value;
            }
        }

        public string ItemName { get; set; }

        private bool _useUniqNames;
        public virtual bool UseUniqName { get => _useUniqNames; set => _useUniqNames = value; }

        public string ItemType { get; protected set; }
        public string OutputDir { get; set; }

        protected readonly string FileName;
        protected readonly RandomController RandController;
        private Random Rand;        
        private readonly int NotifyRate;
        private int RandomSeed;

        protected StringBuilder Output;
        protected StringBuilder ItemSection;
        protected StringBuilder LootTableSection;
        protected StringBuilder LootTableSection2;
        protected StringBuilder StringSection;
        protected string TierPrefix;
        protected string ItemIdPrefix;
        protected string ItemTemplate;
        protected string ItemGenericNameId;

        public BaseGenerator(RandomController controller, string fileName)
        {
            RandController = controller;
            IsActive = true;
            GeneratorSchemaName = GetSchemaName();
            Seed = GetRandomSeed();
            FileName = fileName;
            NotifyRate = 10;

            ItemTemplate = GetTemplate();
            ModsCountMin = 1;
            ModsCountMax = 1;
            ModPower = 1;
            ItemsPrice = 100;
            ItemsCount = 100;
            UseUniqName = false;
        }

        /// <summary>
        /// Start items generation flow...
        /// </summary>
        public void GenerateItems(Action<int> callback)
        {
            RandController.SendStatusMessage($"{GeneratorSchemaName}: start items generation({ItemsCount})");
            Output = new StringBuilder();
            ItemSection = new StringBuilder();
            LootTableSection = new StringBuilder();
            LootTableSection2 = new StringBuilder();
            StringSection = new StringBuilder();
            int itemsProcessed = 0;

            BuildGenericTemplateName();
            for (int currentItem = 0; currentItem < ItemsCount; currentItem++)
            {
                var modsSet = GetNextModSet();
                var itemIdInfo = GetItemIdInfo(currentItem);
                ProcessTemplate(currentItem, itemIdInfo, modsSet);
                ProcessLootTable(currentItem, itemIdInfo);
                ProcessLootTable2(currentItem, itemIdInfo);
                itemsProcessed += 1;
                if (itemsProcessed % NotifyRate == 0)
                {
                    callback.Invoke(itemsProcessed);
                    itemsProcessed = 0;
                }
                Task.Delay(1);
            }
            callback.Invoke(itemsProcessed);

            PostProcessLootTable();
            PostProcessLootTable2();
            RandController.AppendItemsNameBundle(StringSection);
            RandController.AppendRandItemsMeta(GetMeta());
            Output.Append(CommonTemplates.RndFileMetaBlock);
            Output.Append("\r\n");
            Output.Append(ItemSection);
            Output.Append("\r\n");
            Output.Append(LootTableSection);
            Output.Append("\r\n");
            Output.Append(LootTableSection2);
            SaveResult();
            RandController.SendStatusMessage($"{GeneratorSchemaName}: completed.");
        }
        /// <summary>
        /// Creates empty files to provide mods ability to work.
        /// (initialize empty funcs to call)
        /// </summary>
        public void GenerateMock()
        {
            Output = new StringBuilder();
            StringBuilder lootTable = new StringBuilder(CommonTemplates.ItemLootTableMock);
            lootTable.Append("\r\n");
            lootTable.Append(CommonTemplates.ItemLootTableMock2);
            lootTable.Replace("[Tier]", TierPrefix);
            lootTable.Replace("[ItemType]", ItemType);
            Output.AppendLine(lootTable.ToString());
            RandController.AppendRandItemsMeta(GetMeta());
            SaveResult();
        }

        public string GetFilePath() => $"{OutputDir}\\{FileName}";
        public string GetFileFallbackPath() => $"{Application.StartupPath}\\{FileName}";

        /// <summary>
        /// Write all generated data to file
        /// </summary>
        protected void SaveResult()
        {
            RandController.SendStatusMessage($"{GeneratorSchemaName}: saving results...");
            try { File.WriteAllText(GetFilePath(), Output.ToString(), Encoding.GetEncoding(AppConfigsProvider.Configs.OutputFilesEncoding)); }
            catch (DirectoryNotFoundException) { File.WriteAllText(GetFileFallbackPath(), Output.ToString()); }
            catch (Exception ex)
            {
                RandController.SendStatusMessage($"{GeneratorSchemaName}: Can't save {FileName}!\r\nMessage: {ex.Message}");
                return;
            }
            RandController.SendStatusMessage($"{GeneratorSchemaName}: {FileName} saved!");
        }

        /// <summary>
        /// Set item template to work on
        /// </summary>
        public abstract string GetTemplate();

        /// <summary>
        /// Get specific items visual strings
        /// </summary>
        protected abstract string GetItemVisual();

        /// <summary>
        /// Returns pre-processed item template
        /// with customized count of mods
        /// </summary>
        protected virtual string PreProcessTemplate(ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(ItemTemplate);
            var slotsData = BuildTemplateSlotsData(modsSet.ModsCount);
            template.Replace("[ModsText]", slotsData.ModTextSection.TrimEnd(CommonTemplates.EndTrimChars));
            template.Replace("[ModsEquip]", slotsData.ModEquipSection.TrimEnd(CommonTemplates.EndTrimChars));
            template.Replace("[ModsUnEquip]", slotsData.ModUnEquipSection.TrimEnd(CommonTemplates.EndTrimChars));
            return template.ToString();
        }
        /// <summary>
        /// Handle template to fill it with different data
        /// </summary>
        protected virtual void ProcessTemplate(int itemIndex, (string FullId, string Id) itemIdInfo, ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(PreProcessTemplate(modsSet));
            template.Replace("[IdPrefix]", ItemIdPrefix);
            template.Replace("[Id]", itemIdInfo.Id);
            template.Replace("[Price]", GetItemPrice().ToString());
            template.Replace("[Visual]", GetItemVisual());            

            ProcessTemplateMods(template, modsSet);
            ProcessTemplateName(itemIdInfo, template);
            PostProcessTemplate(template);
            ItemSection.AppendLine(template.ToString());
        }

        protected virtual void PostProcessTemplate(StringBuilder template) 
        {

        }

        /// <summary>
        /// Add itemInfo to loot table
        /// </summary>
        protected virtual void ProcessLootTable(int itemIndex, (string FullId, string Id) itemIdInfo)
        {
            StringBuilder lootTableTemplate = new StringBuilder($"\t{CommonTemplates.ItemLootTableTemplateString}");
            lootTableTemplate.Replace("[ItemIndex]", itemIndex.ToString());
            lootTableTemplate.Replace("[ItemId]", itemIdInfo.FullId);
            if(itemIndex == 0)
                lootTableTemplate.Replace("else ", string.Empty);
            LootTableSection.AppendLine(lootTableTemplate.ToString());
        }

        protected virtual void ProcessLootTable2(int itemIndex, (string FullId, string Id) itemIdInfo)
        {
            StringBuilder lootTableTemplate = new StringBuilder($"\t{CommonTemplates.ItemLootTableTemplateString2}");
            lootTableTemplate.Replace("[ItemIndex]", itemIndex.ToString());
            lootTableTemplate.Replace("[ItemId]", itemIdInfo.FullId);
            if (itemIndex == 0)
                lootTableTemplate.Replace("else ", string.Empty);
            LootTableSection2.AppendLine(lootTableTemplate.ToString());
        }
        /// <summary>
        /// Finish loot table generation
        /// </summary>
        protected virtual void PostProcessLootTable()
        {
            StringBuilder lootTable = new StringBuilder(CommonTemplates.ItemLootTableHeader);
            lootTable.Replace("[Tier]", TierPrefix.TrimEnd('_'));
            lootTable.Replace("[ItemType]", ItemType);
            lootTable.Replace("[ItemsCount]", (ItemsCount).ToString());
            lootTable.Replace("[Price]", GetItemPrice().ToString());
            lootTable.Append($"\r\n{LootTableSection.ToString().TrimEnd(CommonTemplates.EndTrimChars)}");
            lootTable.Append(CommonTemplates.LootTableSectionEnd);
            LootTableSection = lootTable;
        }

        protected virtual void PostProcessLootTable2()
        {
            StringBuilder lootTable = new StringBuilder(CommonTemplates.ItemLootTableHeader2);
            lootTable.Replace("[Tier]", TierPrefix.TrimEnd('_'));
            lootTable.Replace("[ItemType]", ItemType);
            lootTable.Replace("[ItemsCount]", (ItemsCount).ToString());
            lootTable.Replace("[Price]", GetItemPrice().ToString());
            lootTable.Append($"\r\n{LootTableSection2.ToString().TrimEnd(CommonTemplates.EndTrimChars)}");
            lootTable.Append(CommonTemplates.LootTableSectionEnd);
            LootTableSection2 = lootTable;
        }
        /// <summary>
        /// Build preprocessed slot data to inject in ItemTemplate
        /// instead placeholders
        /// </summary>
        private (string ModTextSection, string ModEquipSection, string ModUnEquipSection) BuildTemplateSlotsData(int modsCount)
        {
            StringBuilder textSection = new StringBuilder();
            StringBuilder equipSection = new StringBuilder();
            StringBuilder unequipSection = new StringBuilder();

            int textIndex = modsCount < 5 ? 1 : 0; 
            for (int index = 0; index < modsCount; index++)
            {
                StringBuilder textLine_text = new StringBuilder(CommonTemplates.ItemModTextString_Text);
                StringBuilder textLine_value = new StringBuilder(CommonTemplates.ItemModTextString_Value);
                StringBuilder equipLine = new StringBuilder(CommonTemplates.ItemModEquipString);
                StringBuilder unequipLine = new StringBuilder(CommonTemplates.ItemModUnEquipString);

                textLine_text.Replace("[Index]", textIndex.ToString());
                textLine_value.Replace("[Index]", textIndex.ToString());
                equipLine.Replace("[Index]", index.ToString());
                unequipLine.Replace("[Index]", index.ToString());

                if (textIndex <= MaxModsTextCount)
                {
                    textSection.Append($"\t{textLine_text}\r\n");
                    textSection.Append($"\t{textLine_value}\r\n");
                }
                equipSection.Append($"\t{equipLine}\r\n");
                unequipSection.Append($"\t{unequipLine}\r\n");
                textIndex += 1;
            }
            return (textSection.ToString(), equipSection.ToString(), unequipSection.ToString());
        }

        /// <summary>
        /// Fills generated mod slots with mods
        /// </summary>
        protected virtual void ProcessTemplateMods(StringBuilder template, ItemModsSet modsSet)
        {
            string modValue;
            int textIndex = modsSet.ModsCount < 5 ? 1 : 0;
            for (int modIndex = 0; modIndex < modsSet.ModsCount; modIndex++)
            {
                modValue = GetItemModValue(modsSet.ItemMods[modIndex]);
                template.Replace($"[ModText_{textIndex}]", modsSet.ItemMods[modIndex].Template_Text);
                template.Replace($"[ModValue_{textIndex}]", modValue);
                template.Replace($"[ModEquip_{modIndex}]", $"\t{GetItemModString_OnEquip(modsSet.ItemMods[modIndex], modValue)}");
                template.Replace($"[ModUnEquip_{modIndex}]", $"\t{GetItemModString_OnUnequip(modsSet.ItemMods[modIndex], modValue)}");
                textIndex += 1;
            }
        }

        /// <summary>
        /// Generate uniq name or just set default one
        /// </summary>
        protected virtual void ProcessTemplateName((string FullId, string Id) itemIdInfo, StringBuilder template)
        {
            if (UseUniqName)
            {
                StringBuilder nameTemplate = new StringBuilder(CommonTemplates.ItemNameTemplateString);
                var nameId = $"str_{itemIdInfo.FullId}_name";
                nameTemplate.Replace("[StringName]", nameId);
                nameTemplate.Replace("[StringValue]", GetUniqueName());
                template.Replace("[NameId]", nameId);
                StringSection.AppendLine(nameTemplate.ToString());
            }
            else
                template.Replace("[NameId]", $"{ItemGenericNameId}");
        }

        protected virtual void BuildGenericTemplateName()
        {
            StringBuilder nameTemplate = new StringBuilder(CommonTemplates.ItemNameTemplateString);
            var nameId = $"str_{GetSchemaName()}_name";
            nameTemplate.Replace("[StringName]", nameId);
            nameTemplate.Replace("[StringValue]", ItemName);
            StringSection.AppendLine(nameTemplate.ToString());
            ItemGenericNameId = nameId;
        }

        protected virtual StringBuilder GetMeta()
        {
            StringBuilder template = new StringBuilder(CommonTemplates.RandItemMetaString);
            template.Replace("[SchemaName]", GetSchemaName());
            template.Replace("[Seed]", IsActive ? Seed.ToString() : (-1).ToString());
            return template;
        }

        protected virtual ItemMod[] GetItemsMods() => 
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id < 100).ToArray();

        /// <summary>
        /// Get any random mod from allowed list
        /// </summary>
        private ItemMod GetNextMod()
        {
            int modIndex = Rand.Next(GetItemsMods().Count());
            ItemMod mod = GetItemsMods()[modIndex];
            return mod;
        }
        /// <summary>
        /// Compile set of item mods, depends on generator settings
        /// </summary>
        private ItemModsSet GetNextModSet()
        {
            int modsCount = Rand.Next(ModsCountMin, ModsCountMax + 1);
            List<ItemMod> itemMods = new List<ItemMod>();
            for (int i = 0; i < modsCount;)
            {
                var mod = GetNextMod();
                if (ValidateMod(mod, itemMods))
                    continue;
                else i++;
                itemMods.Add(mod);
            }

            ItemModsSet set = new ItemModsSet { ItemMods = itemMods, ModsCount = modsCount };
            return set;
        }
        /// <summary>
        /// Check if mod can be applied to mods set
        /// </summary>
        private bool ValidateMod(ItemMod mod, List<ItemMod> mods)
        {
            if (Rand.Next(100) <= mod.ModRarity) return false;
            bool modExist = mods.Any(x => x.Id == mod.Id);
            return modExist;
        }

        private int GetItemPrice()
        {
            int result = ItemsPrice + 
                (ItemsPrice * Rand.Next(-RandController.RandomPriceMagnitude, RandController.RandomPriceMagnitude)) / 100;
            return result < 1 ? 1 : result;
        }
        private (string FullId, string Id) GetItemIdInfo(int itemIndex)
        {
            string itemId = TierPrefix + itemIndex.ToString("00000");
            string itemFullId = ItemIdPrefix + itemId;
            return (itemFullId, itemId);
        }

        private string GetItemModValue(ItemMod itemMod)
        {
            int result = 1;
            result = new Random(GetRandomSeed()).Next(itemMod.ValueMin, itemMod.ValueMax);
            result = (int)(ModPower * result);

            if(result < 1) result = 1;
            return result.ToString();
        }
            
        private string GetItemModString_OnEquip(ItemMod itemMod, string value) =>
            itemMod.Template_OnEquip?.Replace("[Value]", value);        
        private string GetItemModString_OnUnequip(ItemMod itemMod, string value) =>        
            itemMod.Template_OnUnequip?.Replace("[Value]", value);
        

        protected virtual string GetUniqueName()
        {
            string sufix = ItemModsProvider.ItemsSufixes.GetRandomElement().Trim();
            string prefix = ItemModsProvider.ItemsPrefixes.GetRandomElement().Trim();
            string midlname = ItemModsProvider.ItemsAfixes.GetRandomElement().Trim();

            int rand = Rand.Next(100);
            string name = midlname;
            if (rand <= RandController.UniqNameFullnessMagnitude) name = $"{midlname} {sufix}";
            else if (rand <= RandController.UniqNameFullnessMagnitude * 2) name = $"{prefix} {midlname}";
            else name = $"{prefix} {midlname} {sufix}";
            return $"{ItemName} - '{name}'";
        }

        protected virtual string GetSchemaName() => this.GetType().Name;

        protected int GetRandomSeed()
        {
            int result = new Random(RandomSeed).Next();
            RandomSeed += result + (int)DateTime.Now.Ticks;
            if(RandomSeed < 0)
                RandomSeed *= -1;
            result = RandController.Rand.Next(RandomSeed);
            Task.Delay(1);
            return result;
        }

        protected void SetModsCountRange(int min,  int max)
        {
            var val = SetValueRange(min, max, MaxModsCount);
            _modsCountMin = val.Min; 
            _modsCountMax = val.Max;
        }

        protected (int Min, int Max) SetValueRange(int min, int max, int cap)
        {
            (int Min, int Max) result = default;
            if (min < 1) min = 1;
            if (max > cap) max = cap;
            if (min > max) min = max;

            result.Min = min;
            result.Max = max;
            return result;
        }
    }
}
