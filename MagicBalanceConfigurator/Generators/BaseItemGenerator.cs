using MagicBalanceConfigurator.Generators.SerealizebleGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseItemGenerator : BaseGenerator
    {
        protected const int MaxCondValue = 500;

        public override bool UseUniqName { get => true; set => base.UseUniqName = true; }

        protected List<ItemTemplatePreset> ItemTemplatePresets { get; set; }
        protected ItemTemplatePreset CurrentItemPreset { get; set; }
        protected Dictionary<string, int> CurrentConditionsData { get; set; }

        public double ItemCondMultiplier { get; set; }
        protected bool ItemAltConditionMode { get; set; }

        protected int _minItemCondValue;
        public int MinItemCondValue 
        {
            get => _minItemCondValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxItemCondValue) value = MaxItemCondValue;
                _minItemCondValue = value;
            }
        }

        protected int _maxItemCondValue;
        public int MaxItemCondValue 
        {
            get => _maxItemCondValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxCondValue) value = MaxCondValue;
                _maxItemCondValue = value;
            }
        }

        protected string BaseOnEquipFunc { get; set; }
        protected string BaseOnUnEquipFunc { get; set; }

        public BaseItemGenerator(RandomController controller, string fileName) : base(controller, fileName)
        {
            ItemName = string.Empty;
            ItemTemplatePresets = BuildItemTemplatePresets();
            ItemCondMultiplier = 1;
            ItemAltConditionMode = false;
            SetItemCondRange(5, 10);
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 200).ToArray();

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            CurrentConditionsData = new Dictionary<string, int>();
            StringBuilder template = new StringBuilder(base.PreProcessTemplate(modsSet));
            CurrentItemPreset = GetItemTemplatePreset();
            template.Replace("[CondSection]", BuildItemCondSection());

            if(!String.IsNullOrEmpty(CurrentItemPreset.AltOnEquipFunc))
                template.Replace("[BaseOnEquipFunc]", CurrentItemPreset.AltOnEquipFunc);
            if (!String.IsNullOrEmpty(CurrentItemPreset.AltOnUnEquipFunc))
                template.Replace("[BaseOnUnEquipFunc]", CurrentItemPreset.AltOnUnEquipFunc);
            // else
            template.Replace("[BaseOnEquipFunc]", BaseOnEquipFunc);
            template.Replace("[BaseOnUnEquipFunc]", BaseOnUnEquipFunc);

            if (!String.IsNullOrEmpty(CurrentItemPreset.SpecialSection))
                template.Replace("[SpecialSection]", CurrentItemPreset.SpecialSection);
            else
            {
                string templateString = template.ToString();
                Match match = Regex.Match(templateString, @"\n(.*?)\[SpecialSection(.*?)\n\}");
                if (match.Success)
                    template.Replace(match.Value, "}");
                else
                    template.Replace("[SpecialSection]", CurrentItemPreset.SpecialSection);
            }
            template.Replace("[ItemType]", CurrentItemPreset.ItemType);
            template.Replace("[Visual]", GetItemVisual());
            template.Replace("[VisualChange]", GetItemVisualChange());
            return template.ToString();
        }

        protected virtual string BuildItemCondSection()
        {
            StringBuilder condAtrSection = new StringBuilder();
            StringBuilder condValueSection = new StringBuilder();
            StringBuilder result = new StringBuilder();
            int condValue = 0;
            string primaryCondIndex;
            string secondaryCondIndex;
            if(ItemAltConditionMode)
            {
                primaryCondIndex = "2";
                secondaryCondIndex = "1";
            }
            else
            {
                primaryCondIndex = "1";
                secondaryCondIndex = "2";
            }

            StringBuilder condAtrLine = new StringBuilder(CommonTemplates.ItemCondString_Atr);
            StringBuilder condValueLine = new StringBuilder(CommonTemplates.ItemCondString_Value);
            condAtrLine.Replace("[Index]", primaryCondIndex);
            condAtrLine.Replace("[AtrIndex]", CurrentItemPreset.ItemCondStat);
            condValueLine.Replace("[Index]", primaryCondIndex);
            condValue = GetItemCondValue(CurrentItemPreset.ItemCondStat);
            condValueLine.Replace("[CondAtrValue]", condValue.ToString());
            condAtrSection.Append($"\t{condAtrLine}");
            condValueSection.Append($"\t{condValueLine}");
            if (CurrentItemPreset.ItemCondStat.Equals(CommonTemplates.ItemCondAtr_Stamina)) condValue *= 10;
            CurrentConditionsData.Add(CurrentItemPreset.ItemCondStat, condValue);

            if (new Random(GetRandomSeed()).Next(100) > 50)
            {
                var allowedStats = CommonTemplates.ItemCondAtributes.Except(new List<string> { CurrentItemPreset.ItemCondStat })
                    .ToList();
                allowedStats.AddRange(CurrentItemPreset.ExtraConditions);
                string condStat = allowedStats.ToArray().GetRandomElement();
                condAtrLine = new StringBuilder(CommonTemplates.ItemCondString_Atr);
                condValueLine = new StringBuilder(CommonTemplates.ItemCondString_Value);
                condAtrLine.Replace("[Index]", secondaryCondIndex);
                condAtrLine.Replace("[AtrIndex]", condStat);
                condValueLine.Replace("[Index]", secondaryCondIndex);
                condValue = GetItemCondValue(condStat);
                condValueLine.Replace("[CondAtrValue]", condValue.ToString());
                condAtrSection.Append($"\t{condAtrLine}");
                condValueSection.Append($"\t{condValueLine}");
                if (condStat.Equals(CommonTemplates.ItemCondAtr_Stamina)) condValue *= 10;
                CurrentConditionsData.Add(condStat, condValue);
            }
            result.Append(condAtrSection);
            result.Append(condValueSection.ToString().TrimEnd(CommonTemplates.EndTrimChars));
            return result.ToString();
        }

        public virtual int GetItemCondValue(string atr)
        {
            double mult = ItemCondMultiplier;
            int result = new Random(GetRandomSeed()).Next(MinItemCondValue, MaxItemCondValue);
            if (atr == CommonTemplates.ItemCondAtr_Stamina)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Mana)
                mult += 2;
            else if (atr == CommonTemplates.ItemCondAtr_Hp)
                mult += 6;
            else if (atr == CommonTemplates.ItemCondAtr_Bow)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Crosbow)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Shield)
                mult = 1;
            result = (int)(result * mult);

            if (atr == CommonTemplates.ItemCondAtr_Bow && result >= 99) result = 99;
            if (atr == CommonTemplates.ItemCondAtr_Crosbow && result >= 99) result = 99;
            if (atr == CommonTemplates.ItemCondAtr_Shield && result > 1) result = 1;
            if (atr == CommonTemplates.ItemCondAtr_Stamina && result >= 99) result = 99;
            return result;
        }

        protected void SetItemCondRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxCondValue);
            _minItemCondValue = val.Min;
            _maxItemCondValue = val.Max;
        }

        protected override string GetItemVisual() => $"\"{CurrentItemPreset.Visuals.GetRandomElement()}\"";
        protected virtual string GetItemVisualChange() => $"\"{CurrentItemPreset.VisualChanges?.GetRandomElement()}\"";
        protected override string GetItemName()
        {
            if (!String.IsNullOrEmpty(CurrentItemPreset.ItemNamePlaceholder))
                return CurrentItemPreset.ItemNamePlaceholder;
            return base.GetItemName();
        }

        public override GeneratorConfig GetGeneratorConfig()
        {
            var result = base.GetGeneratorConfig();
            result.ItemTemplates = ItemTemplatePresets.
                ConvertAll(new Converter<ItemTemplatePreset, ItemTemplateConfigs>(ItemTemplatePresetToConfigs)).ToList();
            result.ItemCondMultiplier = ItemCondMultiplier;
            return result;
        }
        public override void ApplyGeneratorConfig(GeneratorConfig generatorConfig)
        {
            base.ApplyGeneratorConfig(generatorConfig);
            ItemTemplatePresets = generatorConfig.ItemTemplates == null ? new List<ItemTemplatePreset>() :
                generatorConfig.ItemTemplates.ConvertAll(new Converter<ItemTemplateConfigs, ItemTemplatePreset>(ItemTemplateConfigsToPreset)).ToList();
            ItemCondMultiplier = generatorConfig.ItemCondMultiplier;
        }
        protected static ItemTemplateConfigs ItemTemplatePresetToConfigs(ItemTemplatePreset preset)
        {
            return new ItemTemplateConfigs()
            {
                AltOnEquipFunc = preset.AltOnEquipFunc,
                AltOnUnEquipFunc = preset.AltOnUnEquipFunc,
                ExtraConditions = preset.ExtraConditions,
                ItemCondStat = preset.ItemCondStat,
                ItemType = preset.ItemType,
                ProtBluntMult = preset.ProtBluntMult,
                ProtEdgeMult = preset.ProtEdgeMult,
                ProtFireMult = preset.ProtFireMult,
                ProtFlyMult = preset.ProtFlyMult,
                ProtMagicMult = preset.ProtMagicMult,
                ProtPointMult = preset.ProtPointMult,
                SpecialSection = preset.SpecialSection,
                SpecialSectionExtra = preset.SpecialSectionExtra,
                VisualChanges = preset.VisualChanges,
                Visuals = preset.Visuals,
                VisualsExtra = preset.VisualsExtra,
                WeaponDamageType = preset.WeaponDamageType,
                WeaponExtraRange = preset.WeaponExtraRange,
                ItemNamePlaceholder = preset.ItemNamePlaceholder,
            };
        }
        protected static ItemTemplatePreset ItemTemplateConfigsToPreset(ItemTemplateConfigs config)
        {
            return new ItemTemplatePreset()
            {
                AltOnEquipFunc = config.AltOnEquipFunc,
                AltOnUnEquipFunc = config.AltOnUnEquipFunc,
                ExtraConditions = config.ExtraConditions,
                ItemCondStat = config.ItemCondStat,
                ItemType = config.ItemType,
                ProtBluntMult = config.ProtBluntMult,
                ProtEdgeMult = config.ProtEdgeMult,
                ProtFireMult = config.ProtFireMult,
                ProtFlyMult = config.ProtFlyMult,
                ProtMagicMult = config.ProtMagicMult,
                ProtPointMult = config.ProtPointMult,
                SpecialSection = config.SpecialSection,
                SpecialSectionExtra = config.SpecialSectionExtra,
                VisualChanges = config.VisualChanges,
                Visuals = config.Visuals,
                VisualsExtra = config.VisualsExtra,
                WeaponDamageType = config.WeaponDamageType,
                WeaponExtraRange = config.WeaponExtraRange,
                ItemNamePlaceholder = config.ItemNamePlaceholder,
            };
        }

        protected virtual ItemTemplatePreset GetItemTemplatePreset() => (ItemTemplatePreset)ItemTemplatePresets.GetRandomObj();
        protected abstract List<ItemTemplatePreset> BuildItemTemplatePresets();
        protected class ItemTemplatePreset
        {
            public string ItemNamePlaceholder { get; set; }
            public string[] Visuals { get; set; } = new string[] { };
            public string[] VisualsExtra { get; set; } = new string[] { };
            public string[] VisualChanges { get; set; } = new string[] { };
            public string[] ExtraConditions { get; set; } = new string[] { };
            public string ItemType { get; set; }
            public string WeaponDamageType { get; set; }
            public int WeaponExtraRange { get; set; }
            public string ItemCondStat { get; set; }
            public string AltOnEquipFunc { get; set; }
            public string AltOnUnEquipFunc { get; set; }
            public string SpecialSection { get; set; } = String.Empty;
            public string SpecialSectionExtra { get; set; } = String.Empty;            

            public double ProtBluntMult { get; set; } = 1;
            public double ProtEdgeMult { get; set; } = 1;
            public double ProtFireMult { get; set; } = 1;
            public double ProtMagicMult { get; set; } = 1;
            public double ProtPointMult { get; set; } = 1;
            public double ProtFlyMult { get; set; } = 1;
        }
    }
}
