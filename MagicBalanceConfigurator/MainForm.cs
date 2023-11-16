using MagicBalanceConfigurator.Configs;
using MagicBalanceConfigurator.Generators;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public partial class MainForm : Form
    {
        private RandomController RandomController;
        private ModConfigsController ModConfigsController;
        private ModConfigsTextHighlighter ModConfigsHighlighter;
        private PackagesController PackagesController;
        private ScriptsPatcher PatchController;
        private MessageBoxLocalizer MsgLocalizer;

        private bool IsModConfigsControllerInitialized;
        private bool IsRandUiBlocked;

        public MainForm() : base()
        {
            InitializeComponent();
            AppConfigsProvider.GetConfigs();
            MsgLocalizer = new MessageBoxLocalizer();

            RandomController = new RandomController(this);
            RandomController.OnNewStatusMessage += PrintLogMessage;
            RandomController.OnProgressBarUpdate += UpdateProgressBar;
            RandomController.OnUiBlockUpdate += (bool isBlocked) =>
                { IsRandUiBlocked = isBlocked; UpdateRandomPageUi(); };
        }

        private void InitializeModConfigsController()
        {
            try
            {
                if (String.IsNullOrEmpty(ConfigPresetsBox.Text))
                    ConfigPresetsBox.Text = ConfigPresetsBox.Items[0].ToString();

                var moduleName = ConfigPresetsBox.Text;
                var module = PackagesController.GetPackage(moduleName);
                if (module != null)
                {
                    ModConfigsController = new ModConfigsController(module.Directory);
                    ModConfigsHighlighter = new ModConfigsTextHighlighter(ModConfigsTextBox);
                    ModConfigsTextBox.Clear();
                    ModConfigsTextBox.AppendText(ModConfigsController.RawConfigs);
                }
                else
                {
                    MessageBox.Show("Selected package not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                IsModConfigsControllerInitialized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MsgLocalizer.GetMessage("ConfigsControllerInitError") + $"\r\nError: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IsModConfigsControllerInitialized = false;
            }
            ((Control)ModConfigsPage).Enabled = IsModConfigsControllerInitialized;
            ModConfigsTextBox.Enabled = IsModConfigsControllerInitialized;
        }

        private void SaveConfigs()
        {
            AppConfigsProvider.Configs.GamePath = GamePathTextBox.Text;
            AppConfigsProvider.Configs.Language = LanguageSelectBox.Text;
            AppConfigsProvider.SetConfigs();
        }

        private void PrintLogMessage(string strMessage) { ConsoleTextBox.Text += strMessage + "\r\n"; }
        private void UpdateProgressBar(int processedItems, int maxItems)
        {
            GenerationProgressBar.Value = processedItems;
            GenerationProgressBar.Maximum = maxItems;
            ProgressLabel.Text = $"{processedItems} / {maxItems}";
        }

        private void UpdateRandomPageUi()
        {
            GenerateBtn.Enabled = !IsRandUiBlocked;
            ItemPriceRangeBox.Enabled = !IsRandUiBlocked;
            ItemsCountBox.Enabled = !IsRandUiBlocked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitAppConfigsPage();
            InitPackagesPage();
            InitRandomPage();
        }

        private void InitAppConfigsPage()
        {
            if (!AppConfigsProvider.IsGamePathCorrect())
                AppConfigsProvider.DetectAndSetGamePath();

            GamePathTextBox.Text = AppConfigsProvider.Configs.GamePath;
            VdfsArchiveBox.Text = AppConfigsProvider.Configs.GameArchive;
            LanguageSelectBox.Text = AppConfigsProvider.Configs.Language;
            OutputFilesCodepageBox.Text = AppConfigsProvider.Configs.OutputFilesEncoding;
        }

        private void InitRandomPage()
        {
            ItemModsProvider.InitializeItemsMods();
            UpdateRandomList();
            ItemPriceRangeBox.Value = RandomController.RandomPriceMagnitude;
            BuildRandomItemsPackageBox.Checked = RandomController.BuildPackage;
        }
        private void UpdateRandomList()
        {
            GeneratorDataGrid.Rows.Clear();
            foreach (var generator in RandomController.Generators)
            {
                var row = generator.GetData();
                GeneratorDataGrid.Rows.Add(row);
            };
        }

        private void InitPackagesPage()
        {
            PackagesController = new PackagesController();
            PatchController = new ScriptsPatcher();
            UpdatepackagesList(true);
            PackageListUpdater.Enabled = true;
        }
        private void UpdatepackagesList(bool forced = false)
        {
            if (PackagesGridView.IsCurrentCellInEditMode) return;
            PackagesGridView.ClearSelection();
            PackagesController.CheckPackages();

            if (PackagesController.RequireUpdate || forced)
            {
                PackagesGridView.Rows.Clear();
                foreach (var package in PackagesController.GetSortedPackages())
                {
                    var row = package.GetData();
                    PackagesGridView.Rows.Add(row);
                };
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Clear();
            RandomController.StartGeneration();
        }

        private void SetGothicDirBtn_Click(object sender, EventArgs e)
        {
            FileOpenDialog.InitialDirectory = AppConfigsProvider.GetG2DataDir();
            if (FileOpenDialog.ShowDialog(this) == DialogResult.OK)
            {
                string archiveName = Path.GetFileName(FileOpenDialog.FileName);
                AppConfigsProvider.Configs.GameArchive = archiveName;
                VdfsArchiveBox.Text = AppConfigsProvider.Configs.GameArchive;
                SaveConfigs();
            }
        }

        private void ConfigElement_Leave(object sender, EventArgs e) => SaveConfigs();

        private object TrySetValue(object value, object backUp, Func<object> act)
        {
            if (value == null) return backUp;
            try { value = act.Invoke(); }
            catch { value = backUp; }
            return value;
        }

        private void GeneratorDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string schemaName = GeneratorDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            var generator = RandomController.GetGenerator(schemaName);

            if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "IsActiveColumn")
                e.Value = TrySetValue(e.Value, generator.IsActive, () => {
                    generator.IsActive = Convert.ToBoolean(e.Value);
                    return generator.IsActive;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "QuantityColumn")
                e.Value = TrySetValue(e.Value, generator.ItemsCount, () => {
                    generator.ItemsCount = Convert.ToInt32(e.Value);
                    return generator.ItemsCount;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "PriceColumn")
                e.Value = TrySetValue(e.Value, generator.ItemsPrice, () => {
                    generator.ItemsPrice = Convert.ToInt32(e.Value);
                    return generator.ItemsPrice;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "PowerColumn")
                e.Value = TrySetValue(e.Value, generator.ModPower, () =>
                {
                    generator.ModPower = Convert.ToDouble(e.Value);
                    return generator.ModPower;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "ItemNameColumn")
                e.Value = TrySetValue(e.Value, generator.IsActive, () => {
                    generator.ItemName = Convert.ToString(e.Value);
                    return generator.ItemName;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "UseUniqNameColumn")
                e.Value = TrySetValue(e.Value, generator.IsActive, () => {
                    generator.UseUniqName = Convert.ToBoolean(e.Value);
                    return generator.UseUniqName;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "SeedColumn")
                e.Value = TrySetValue(e.Value, generator.Seed, () => {
                    generator.Seed = Convert.ToInt32(e.Value);
                    return generator.Seed;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "ModsMaxColumn")
                e.Value = TrySetValue(e.Value, generator.ModsCountMax, () => {
                    generator.ModsCountMax = Convert.ToInt32(e.Value);
                    return generator.ModsCountMax;
                });

            else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "ModsMinColumn")
                e.Value = TrySetValue(e.Value, generator.ModsCountMin, () => {
                    generator.ModsCountMin = Convert.ToInt32(e.Value);
                    return generator.ModsCountMin;
                });

            BaseItemGenerator baseItemGenerator = generator as BaseItemGenerator;
            if (baseItemGenerator != null)
            {
                if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "CondPower")
                    e.Value = TrySetValue(e.Value, baseItemGenerator.ItemCondMultiplier, () => {
                        baseItemGenerator.ItemCondMultiplier = Convert.ToDouble(e.Value);
                        return baseItemGenerator.ItemCondMultiplier;
                    });
            }

            BaseWeaponGenerator baseWeaponGenerator = generator as BaseWeaponGenerator;
            if (baseWeaponGenerator != null)
            {
                if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "DamagePower")
                    e.Value = TrySetValue(e.Value, baseWeaponGenerator.WeaponDamageMult, () => {
                        baseWeaponGenerator.WeaponDamageMult = Convert.ToDouble(e.Value);
                        return baseWeaponGenerator.WeaponDamageMult;
                    });
                else if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "RangePower")
                    e.Value = TrySetValue(e.Value, baseWeaponGenerator.WeaponRangeMult, () => {
                        baseWeaponGenerator.WeaponRangeMult = Convert.ToDouble(e.Value);
                        return baseWeaponGenerator.WeaponRangeMult;
                    });
            }

            BaseArmorGenerator baseArmorGenerator = generator as BaseArmorGenerator;
            if (baseArmorGenerator != null)
            {
                if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "ProtPower")
                    e.Value = TrySetValue(e.Value, baseArmorGenerator.ArmorProtectionMult, () => {
                        baseArmorGenerator.ArmorProtectionMult = Convert.ToDouble(e.Value);
                        return baseArmorGenerator.ArmorProtectionMult;
                    });
            }
            
            BasePotionGenerator basePotionGenerator = generator as BasePotionGenerator;
            if(basePotionGenerator != null)
            {
                if (GeneratorDataGrid.Columns[e.ColumnIndex].Name == "PotionDurationPower")
                    e.Value = TrySetValue(e.Value, basePotionGenerator.PotionDurationMult, () => {
                        basePotionGenerator.PotionDurationMult = Convert.ToDouble(e.Value);
                        return basePotionGenerator.PotionDurationMult;
                    });
                
            }
        }
        private void PackagesGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string pckgName = PackagesGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            var package = PackagesController.GetPackage(pckgName);
            bool saveRequired = false;
            if (package == null) return;

            if (PackagesGridView.Columns[e.ColumnIndex].Name == "IsPackageEnabledColumn")
            {
                bool valBefore = package.IsEnabled;
                e.Value = TrySetValue(e.Value, package.IsEnabled, () =>
                {
                    package.IsEnabled = Convert.ToBoolean(e.Value);
                    return package.IsEnabled;
                });
                if (valBefore != package.IsEnabled)
                    saveRequired = true;
            }
            if (PackagesGridView.Columns[e.ColumnIndex].Name == "LoadOrderColumn")
            {
                int valBefore = package.LoadOrder;
                e.Value = TrySetValue(e.Value, package.LoadOrder, () =>
                {
                    package.LoadOrder = Convert.ToInt32(e.Value);
                    return package.LoadOrder;
                });
                if (valBefore != package.LoadOrder)
                    saveRequired = true;
            }

            if (saveRequired)
            {
                PackagesController.SavePackageMeta(package);
            }
            PackagesGridView.ClearSelection();
        }
        private void timer1_Tick(object sender, EventArgs e) => UpdatepackagesList();


        private void ModConfigsTextBox_TextChanged(object sender, EventArgs e) =>
            ModConfigsController?.UpdateConfigs(ModConfigsTextBox.Text);

        private void ItemPriceRangeBox_ValueChanged(object sender, EventArgs e) =>
            RandomController.RandomPriceMagnitude = Convert.ToInt32(ItemPriceRangeBox.Value);

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            System.Diagnostics.Process.Start(Consts.HomePageLink);

        private void InstallPackagesBtn_Click(object sender, EventArgs e)
        {
            try { PackagesController.InstallSelectedPackages(CleanUpAutorunBox.Checked); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(MsgLocalizer.GetMessage("PckgsInstalled"), "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuildRandomItemsPackageBox_CheckedChanged(object sender, EventArgs e) =>
            RandomController.BuildPackage = BuildRandomItemsPackageBox.Checked;

        private void ItemModConfigsBtn_Click(object sender, EventArgs e)
        {
            var modsWindow = new ModsConfigsWindow();
            modsWindow.ShowDialog();
        }

        private void TabsPanel_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == ModConfigsPage)
                InitializeModConfigsController();
        }

        private void RunPatchBtn_Click(object sender, EventArgs e)
        {
            if (!AppConfigsProvider.IsGamePathCorrect())
            {
                var dialogResult =
                    MessageBox.Show(MsgLocalizer.GetMessage("GamePathIncorrectCompiling"), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes) return;
            }

            var agreement = MessageBox.Show(MsgLocalizer.GetMessage("CompilingNotification"), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (agreement != DialogResult.Yes) return;
            try
            {
                PatchController.BackUpFiles();
                PatchController.PatchGame(CleanInstallBox.Checked);
            }
            catch (Exception exeption)
            {
                MessageBox.Show($"Error: {exeption.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            MessageBox.Show(MsgLocalizer.GetMessage("CopilationSuccess"), "Success!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LanguageSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageSelectBox.SelectedItem.ToString() == "Rus")
            {
                AppConfigsProvider.Configs.Language = "Rus";
                ChangeLanguage("ru");
            }
            else
            {
                AppConfigsProvider.Configs.Language = "Eng";
                ChangeLanguage("en");
            }

            AppConfigsProvider.SetConfigs();
        }
        private void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang, false);
            var culture = Thread.CurrentThread.CurrentUICulture;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

            resources.ApplyResources(InstallPage, InstallPage.Name, culture);
            LocalizeChilds(InstallPage, resources);
            resources.ApplyResources(AppConfigsPage, AppConfigsPage.Name, culture);
            LocalizeChilds(AppConfigsPage, resources);
            resources.ApplyResources(ModConfigsPage, ModConfigsPage.Name, culture);
            LocalizeChilds(ModConfigsPage, resources);
            resources.ApplyResources(RandomPage, RandomPage.Name, culture);
            LocalizeChilds(RandomPage, resources);
            LocalizeChilds(this, resources);

            resources.ApplyResources(IsActiveColumn, IsActiveColumn.Name, culture);
            resources.ApplyResources(IsPackageEnabledColumn, IsPackageEnabledColumn.Name, culture);
            resources.ApplyResources(ModsMaxColumn, ModsMaxColumn.Name, culture);
            resources.ApplyResources(ModsMinColumn, ModsMinColumn.Name, culture);
            resources.ApplyResources(PackageNameColumn, PackageNameColumn.Name, culture);
            resources.ApplyResources(PackageAuthorColumn, PackageAuthorColumn.Name, culture);
            resources.ApplyResources(PackageDescriptionColumn, PackageDescriptionColumn.Name, culture);
            resources.ApplyResources(PackageVersionColumn, PackageVersionColumn.Name, culture);
            resources.ApplyResources(PowerColumn, PowerColumn.Name, culture);
            resources.ApplyResources(PriceColumn, PriceColumn.Name, culture);
            resources.ApplyResources(QuantityColumn, QuantityColumn.Name, culture);
            resources.ApplyResources(SeedColumn, SeedColumn.Name, culture);
            resources.ApplyResources(SchemaNameColumn, SchemaNameColumn.Name, culture);
            resources.ApplyResources(UseUniqNameColumn, UseUniqNameColumn.Name, culture);
            resources.ApplyResources(ItemNameColumn, ItemNameColumn.Name, culture);
        }
        private void LocalizeChilds(Control control, ComponentResourceManager resources)
        {
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name, Thread.CurrentThread.CurrentUICulture);
                LocalizeChilds(c, resources);
            }
        }

        private void ItemNamesBtn_Click(object sender, EventArgs e)
        {
            var neamesWindow = new ItemNamesWindow();
            neamesWindow.ShowDialog();
        }

        private void SelectBackupArchBtn_Click(object sender, EventArgs e)
        {
            FileOpenDialog.InitialDirectory = AppConfigsProvider.GetG2DataDir();
            if (FileOpenDialog.ShowDialog(this) == DialogResult.OK)
            {
                string archiveName = FileOpenDialog.FileName;
                PatchController.SetBackUpArchive(archiveName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void OutputFilesCodepageBox_TextUpdate(object sender, EventArgs e)
        {
            AppConfigsProvider.Configs.OutputFilesEncoding = OutputFilesCodepageBox.Text;
            AppConfigsProvider.SetConfigs();
        }
        private void OutputFilesCodepageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfigsProvider.Configs.OutputFilesEncoding = OutputFilesCodepageBox.Text;
            AppConfigsProvider.SetConfigs();
        }

        private void ItemsCountBox_ValueChanged(object sender, EventArgs e)
        { RandomController.SetItemsCount((int)ItemsCountBox.Value); UpdateRandomList(); }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(Consts.DonationLink1);

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start(Consts.DonationLink2);

        private void ConfigPresetsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModConfigsController != null)
            {
                var moduleName = ConfigPresetsBox.Text;
                var module = PackagesController.GetPackage(moduleName);
                if (module != null)
                {
                    ModConfigsController.UpdateConfigs(ModConfigsTextBox.Text);
                    ModConfigsController.UpdateConfigsPath(module.Directory);
                    ModConfigsTextBox.Clear();
                    ModConfigsTextBox.AppendText(ModConfigsController.RawConfigs);
                }
                else
                {
                    MessageBox.Show("Selected package not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(ConfigPresetsBox.Text))
                    ConfigPresetsBox.Text = ConfigPresetsBox.Items[0].ToString();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("Z756674559775");
            MessageBox.Show("Adress copied to clipboard!");
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("3HZFxPqyJnrNLSw7L8hJt9A2hZJjGgdGJe");
            MessageBox.Show("Adress copied to clipboard!");
        }
    }
}
