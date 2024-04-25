using MagicBalanceConfigurator.Configs;
using MagicBalanceConfigurator.Generators;
using MagicBalanceConfigurator.Generators.SerealizebleGenerators;
using MagicBalanceConfigurator.Packages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public delegate void AddStatusMessageDelegate(string strMessage);
    public delegate void UpdateProgressBarDelegate(int processedItems, int maxItems);
    public delegate void UpdateUiBlockDelegate(bool isEnabled);

    public class RandomController
    {
        public event AddStatusMessageDelegate OnNewStatusMessage;
        public event UpdateProgressBarDelegate OnProgressBarUpdate;
        public event UpdateUiBlockDelegate OnUiBlockUpdate;

        public List<BaseGenerator> Generators { get; private set; }
        public readonly Random Rand;
        private Form MainForm;
        private StringBuilder ItemsUniqNames;
        private StringBuilder RandItemsMeta;
        public string OutputDir { get; private set; }

        public int TotalItemsToGenerate { get; private set; }
        public int ItemsGenerated { get; private set; }

        public int RandomPriceMagnitude { get; set; }
        public int UniqNameFullnessMagnitude { get; set; }
        public bool BuildPackage { get; set; }
        public bool EnableColorfullPotions { get; set; }

        public RandomController(Form winForm) 
        {
            MainForm = winForm;
            Rand = new Random();
            BuildGenerators();
            RandomPriceMagnitude = 25;
            UniqNameFullnessMagnitude = 15;
            BuildPackage = true;
        }

        protected void BuildGenerators()
        {
            Generators = new List<BaseGenerator>()
            {
                new Aml_T1_Generator(this),
                new Aml_T2_Generator(this),
                new Aml_T3_Generator(this),
                new Aml_T4_Generator(this),

                new Rng_T1_Generator(this),
                new Rng_T2_Generator(this),
                new Rng_T3_Generator(this),
                new Rng_T4_Generator(this),
                                
                new Blt_T1_Generator(this),
                new Blt_T2_Generator(this),
                new Blt_T3_Generator(this),
                new Blt_T4_Generator(this),

                new Pot_T1_Generator(this),
                new Pot_T2_Generator(this),
                new Pot_T3_Generator(this),
                new Pot_T4_Generator(this),

                new Weap_1h_T1_Generator(this),
                new Weap_1h_T2_Generator(this),
                new Weap_1h_T3_Generator(this),
                new Weap_1h_T4_Generator(this),

                new Weap_Dual_T1_Generator(this),
                new Weap_Dual_T2_Generator(this),
                new Weap_Dual_T3_Generator(this),
                new Weap_Dual_T4_Generator(this),

                new Weap_2h_T1_Generator(this),
                new Weap_2h_T2_Generator(this),
                new Weap_2h_T3_Generator(this),
                new Weap_2h_T4_Generator(this),

                new Weap_Bow_T1_Generator(this),
                new Weap_Bow_T2_Generator(this),
                new Weap_Bow_T3_Generator(this),
                new Weap_Bow_T4_Generator(this),

                new Weap_Crossbow_T1_Generator(this),
                new Weap_Crossbow_T2_Generator(this),
                new Weap_Crossbow_T3_Generator(this),
                new Weap_Crossbow_T4_Generator(this),

                new Weap_Staff_T1_Generator(this),
                new Weap_Staff_T2_Generator(this),
                new Weap_Staff_T3_Generator(this),
                new Weap_Staff_T4_Generator(this),

                new Weap_MagicSword_T1_Generator(this),
                new Weap_MagicSword_T2_Generator(this),
                new Weap_MagicSword_T3_Generator(this),
                new Weap_MagicSword_T4_Generator(this),

                new Armor_Shield_T1_Generator(this),
                new Armor_Shield_T2_Generator(this),
                new Armor_Shield_T3_Generator(this),
                new Armor_Shield_T4_Generator(this),

                new Armor_Helm_T1_Generator(this),
                new Armor_Helm_T2_Generator(this),
                new Armor_Helm_T3_Generator(this),
                new Armor_Helm_T4_Generator(this),

                new Armor_Body_T1_Generator(this),
                new Armor_Body_T2_Generator(this),
                new Armor_Body_T3_Generator(this),
                new Armor_Body_T4_Generator(this),
            };

            var configs = GetGeneratorConfigsBundle();
            if (configs == null)
            {
                SaveGeneratorsConfigs();
                return;
            }

            foreach (var generator in Generators)
            {
                var config = configs.GeneratorConfigs.FirstOrDefault(x => x.SchemaName == generator.GeneratorSchemaName);
                if(config != null)
                    generator.ApplyGeneratorConfig(config);
            }
        }

        public void StartGeneration()
        {
            List<Task> tasks = new List<Task>();
            ItemsGenerated = 0; 
            TotalItemsToGenerate = 0;
            RandItemsMeta = new StringBuilder();
            ItemsUniqNames = new StringBuilder();
            PackageInfo packageInfo = null;

            OutputDir = BuildPackage ? 
                $"{AppConfigsProvider.GetPackagesDir()}\\{Consts.RandomItemsPackageDir}" : AppConfigsProvider.GetAutorunDir();
            if(BuildPackage) 
            {
                PackageBuilder packageBuilder = new PackageBuilder();
                packageInfo = packageBuilder.BuildPackage(Consts.RandomItemsPackageDir, OutputDir, "StonedWizzard", new List<string>() { "StExtMod - Core" },
                    new List<string>() { "StExtMod - RandItemPack Patch", "StExtMod - Main", "StExtMod - User configs", "StExtMod - English" },
                    "2.3.3", "StExtMod - Random items. Required 'StExtMod - Core'", true);
            }

            Generators.ForEach(g =>
            {
                if (g.IsActive) 
                    TotalItemsToGenerate += g.ItemsCount;
            });
            UpdateUiBlock(true);
            UpdateProgressBar(ItemsGenerated, TotalItemsToGenerate);            
            SendStatusMessage($"Random items generation initialized. Items to create: {TotalItemsToGenerate}");

            Task.Run(async () =>
            {
                foreach (var generator in Generators)
                {
                    generator.OutputDir = OutputDir;
                    var task = new Task(() =>
                    {
                        if (generator.IsActive) generator.GenerateItems(ProgressCounter);
                        else generator.GenerateMock();
                    });
                    task.Start();
                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
                UpdateProgressBar(TotalItemsToGenerate - 1, TotalItemsToGenerate);
                await Task.Run(() =>
                {
                    SendStatusMessage("Saving items names...");
                    SaveItemsNames(OutputDir);
                    UpdateProgressBar(TotalItemsToGenerate, TotalItemsToGenerate);
                });                
                SaveRandMeta(OutputDir);
                SendStatusMessage("Items generation completed!");
                UpdateUiBlock(false);
            });
        }

        public void SetItemsCount(int count)
        {
            foreach(var generator in Generators)
                generator.ItemsCount = count;
        }

        private void ProgressCounter(int progress)
        {
            ItemsGenerated += progress;
            UpdateProgressBar(ItemsGenerated, TotalItemsToGenerate);
        }

        public void UpdateProgressBar(int processedItems, int maxItems)
        {
            if (MainForm != null && MainForm.InvokeRequired)
                MainForm.Invoke(new UpdateProgressBarDelegate(UpdateProgressBar), new object[] { processedItems, maxItems });
            else
                OnProgressBarUpdate(processedItems, maxItems);
        }
        public void SendStatusMessage(string strMessage)
        {
            if (MainForm != null && MainForm.InvokeRequired)
                MainForm.Invoke(new AddStatusMessageDelegate(SendStatusMessage), new object[] { strMessage });
            else
                OnNewStatusMessage(strMessage);
        }
        public void UpdateUiBlock(bool isBlocked)
        {
            if (MainForm != null && MainForm.InvokeRequired)
                MainForm.Invoke(new UpdateUiBlockDelegate(UpdateUiBlock), new object[] { isBlocked });
            else
                OnUiBlockUpdate(isBlocked);
        }

        public BaseGenerator GetGenerator(string schemaName) =>
            Generators.FirstOrDefault(g => g.GeneratorSchemaName == schemaName);

        private object AppendItemsNameBundleLocker = new object();
        public void AppendItemsNameBundle(StringBuilder itemsNameBundle)
        {
            lock(AppendItemsNameBundleLocker)
                ItemsUniqNames.Append(itemsNameBundle);
        }

        private object AppendRandItemsMetaLocker = new object();
        public void AppendRandItemsMeta(StringBuilder randItemsMeta)
        {
            RandItemsMeta.Append($"const int StExt_RandomItemsGenerated = true;\r\n");
            lock (AppendRandItemsMetaLocker)
                RandItemsMeta.Append($"{randItemsMeta}\r\n");
        }

        private string GetEnumeratedFilePath(string path, int id) => path.Replace(".d", $"_{id.ToString("00")}.d");
        private List<string> SplitItemsNames()
        {
            const int BlockSize = 20000;
            List<string> result = new List<string>();
            List<string> rawData = new List<string>();

            // Use reader instead just String.Split method to prevent OutOfMemoryException
            using (StringReader reader = new StringReader(ItemsUniqNames.ToString()))
            {
                string readText;
                while ((readText = reader.ReadLine()) != null)
                    rawData.Add(readText);
            }

            for (int i = 0, j = 0; i < rawData.ToArray().Length; j++)
            {
                int index = j * BlockSize;
                StringBuilder block = new StringBuilder();
                var blockData = rawData.Skip(index).Take(BlockSize).ToArray();
                foreach (var item in blockData)
                    block.AppendLine(item);
                i += BlockSize;
                result.Add(block.ToString());
            }
            return result;
        }

        private void SaveItemsNames(string savePath)
        {
            var itemNamesData = SplitItemsNames();
            int index = 0;
            foreach (var itemNameBlock in itemNamesData)
            {
                string path = $"{savePath}\\{GetEnumeratedFilePath(Consts.RandLocalizationFileName, index)}";
                string fallbackPath = $"{Application.StartupPath}\\{GetEnumeratedFilePath(Consts.RandLocalizationFileName, index)}";
                try
                {
                    File.WriteAllText(path, itemNameBlock, Encoding.GetEncoding(AppConfigsProvider.Configs.OutputFilesEncoding));
                }
                catch (DirectoryNotFoundException) { File.WriteAllText(fallbackPath, itemNameBlock); }
                catch (Exception ex)
                {
                    SendStatusMessage($"Can't save {GetEnumeratedFilePath(Consts.RandLocalizationFileName, index)}!\r\nMessage: {ex.Message}");
                    return;
                }
                index += 1;
            }            
            SendStatusMessage($"{Consts.RandLocalizationFileName} files saved!");
        }
        private void SaveRandMeta(string savePath)
        {
            string path = $"{savePath}\\{Consts.RandMetaFileName}";
            string fallbackPath = $"{Application.StartupPath}\\{Consts.RandMetaFileName}";
            RandItemsMeta.AppendLine(String.Empty);
            RandItemsMeta.AppendLine(CommonTemplates.StExt_ItemsGeneratedConst);
            RandItemsMeta.AppendLine(CommonTemplates.StExt_CreateRandomItemMock); 
            RandItemsMeta.AppendLine(CommonTemplates.StExt_ApplyPotionEffectMock);
            RandItemsMeta.AppendLine(CommonTemplates.StExt_RegisterItemBonus);
            RandItemsMeta.AppendLine(CommonTemplates.StExt_ClearItemInfoMock);            
            try { File.WriteAllText(path, RandItemsMeta.ToString()); }
            catch (DirectoryNotFoundException) { File.WriteAllText(fallbackPath, RandItemsMeta.ToString()); }
            catch (Exception ex)
            {
                SendStatusMessage($"Can't save {Consts.RandMetaFileName}!\r\nMessage: {ex.Message}");
                return;
            }
            SendStatusMessage($"{Consts.RandMetaFileName} saved!");
        }

        public void SaveGeneratorsConfigs()
        {
            GeneratorConfigsBundle generatorConfigsBundle = new GeneratorConfigsBundle();
            foreach(var generator in Generators)
                generatorConfigsBundle.GeneratorConfigs.Add(generator.GetGeneratorConfig());
            string path = $"{Consts.GeneratorsConfigsPath}";
            string raw = JsonConvert.SerializeObject(generatorConfigsBundle);
            File.WriteAllText(path, raw);
        }

        private GeneratorConfigsBundle GetGeneratorConfigsBundle()
        {
            try
            {
                string raw = File.ReadAllText($"{Consts.GeneratorsConfigsPath}");
                GeneratorConfigsBundle package = JsonConvert.DeserializeObject<GeneratorConfigsBundle>(raw);
                return package;
            }
            catch { return null; }
        }
    }
}
