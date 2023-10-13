using MagicBalanceConfigurator.Configs;
using MagicBalanceConfigurator.Generators;
using MagicBalanceConfigurator.Packages;
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
            };
        }

        public void StartGeneration()
        {
            List<Task> tasks = new List<Task>();
            ItemsGenerated = 0; 
            TotalItemsToGenerate = 0;
            RandItemsMeta = new StringBuilder();
            ItemsUniqNames = new StringBuilder();

            OutputDir = BuildPackage ? 
                $"{AppConfigsProvider.GetPackagesDir()}\\{Consts.RandomItemsPackageDir}" : AppConfigsProvider.GetAutorunDir();
            if(BuildPackage) 
            {
                PackageBuilder packageBuilder = new PackageBuilder();
                packageBuilder.BuildPackage(Consts.RandomItemsPackageDir, OutputDir, "StonedWizzard", new List<string>() { "StExtMod - Core" },
                    new List<string>() { "StExtMod - RandItemPack Patch", "StExtMod - Main", "StExtMod - User configs", "StExtMod - English" },
                    "2.0.3", "StExtMod - Random items. Required 'StExtMod - Core'", true);
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
                    //await task.ConfigureAwait(false);
                    task.Start();
                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
                SaveItemsNames(OutputDir);
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
            lock (AppendRandItemsMetaLocker)
                RandItemsMeta.Append($"{randItemsMeta}\r\n");
        }

        private void SaveItemsNames(string savePath)
        {
            string path = $"{savePath}\\{Consts.RandLocalizationFileName}";
            string fallbackPath = $"{Application.StartupPath}\\{Consts.RandLocalizationFileName}";
            try { 
                File.WriteAllText(path, ItemsUniqNames.ToString(), Encoding.GetEncoding(AppConfigsProvider.Configs.OutputFilesEncoding)); }
            catch (DirectoryNotFoundException) { File.WriteAllText(fallbackPath, ItemsUniqNames.ToString()); }
            catch (Exception ex)
            {
                SendStatusMessage($"Can't save {Consts.RandLocalizationFileName}!\r\nMessage: {ex.Message}");
                return;
            }
            SendStatusMessage($"{Consts.RandLocalizationFileName} saved!");
        }
        private void SaveRandMeta(string savePath)
        {
            string path = $"{savePath}\\{Consts.RandMetaFileName}";
            string fallbackPath = $"{Application.StartupPath}\\{Consts.RandMetaFileName}";

            RandItemsMeta.AppendLine(CommonTemplates.StExt_CreateRandomItemMock); 
            RandItemsMeta.AppendLine(CommonTemplates.StExt_ApplyPotionEffectMock);
            try { File.WriteAllText(path, RandItemsMeta.ToString()); }
            catch (DirectoryNotFoundException) { File.WriteAllText(fallbackPath, RandItemsMeta.ToString()); }
            catch (Exception ex)
            {
                SendStatusMessage($"Can't save {Consts.RandMetaFileName}!\r\nMessage: {ex.Message}");
                return;
            }
            SendStatusMessage($"{Consts.RandMetaFileName} saved!");
        }
    }
}
