namespace MagicBalanceConfigurator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabsPanel = new System.Windows.Forms.TabControl();
            this.InstallPage = new System.Windows.Forms.TabPage();
            this.CleanUpAutorunBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CleanInstallBox = new System.Windows.Forms.CheckBox();
            this.SelectBackupArchBtn = new System.Windows.Forms.Button();
            this.RunPatchBtn = new System.Windows.Forms.Button();
            this.InstallPackagesBtn = new System.Windows.Forms.Button();
            this.PackagesGridView = new System.Windows.Forms.DataGridView();
            this.IsPackageEnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LoadOrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageAuthorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomPage = new System.Windows.Forms.TabPage();
            this.ItemsCountBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemNamesBtn = new System.Windows.Forms.Button();
            this.ItemModConfigsBtn = new System.Windows.Forms.Button();
            this.BuildRandomItemsPackageBox = new System.Windows.Forms.CheckBox();
            this.ItemPriceRangeBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.GeneratorDataGrid = new System.Windows.Forms.DataGridView();
            this.IsActiveColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SchemaNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModsMinColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModsMaxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PowerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamagePower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangePower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProtPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotionDurationPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseUniqNameColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SeedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerationProgressBar = new System.Windows.Forms.ProgressBar();
            this.ConsoleTextBox = new System.Windows.Forms.RichTextBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.ModConfigsPage = new System.Windows.Forms.TabPage();
            this.ModConfigsTextBox = new System.Windows.Forms.RichTextBox();
            this.AppConfigsPage = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.OutputFilesCodepageBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VdfsArchiveBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.LanguageSelectBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SetGothicDirBtn = new System.Windows.Forms.Button();
            this.GamePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DirBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.PackageListUpdater = new System.Windows.Forms.Timer(this.components);
            this.FileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.TabsPanel.SuspendLayout();
            this.InstallPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackagesGridView)).BeginInit();
            this.RandomPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPriceRangeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDataGrid)).BeginInit();
            this.ModConfigsPage.SuspendLayout();
            this.AppConfigsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabsPanel
            // 
            resources.ApplyResources(this.TabsPanel, "TabsPanel");
            this.TabsPanel.Controls.Add(this.InstallPage);
            this.TabsPanel.Controls.Add(this.RandomPage);
            this.TabsPanel.Controls.Add(this.ModConfigsPage);
            this.TabsPanel.Controls.Add(this.AppConfigsPage);
            this.TabsPanel.Name = "TabsPanel";
            this.TabsPanel.SelectedIndex = 0;
            this.TabsPanel.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabsPanel_Selected);
            // 
            // InstallPage
            // 
            resources.ApplyResources(this.InstallPage, "InstallPage");
            this.InstallPage.Controls.Add(this.CleanUpAutorunBox);
            this.InstallPage.Controls.Add(this.button1);
            this.InstallPage.Controls.Add(this.label3);
            this.InstallPage.Controls.Add(this.CleanInstallBox);
            this.InstallPage.Controls.Add(this.SelectBackupArchBtn);
            this.InstallPage.Controls.Add(this.RunPatchBtn);
            this.InstallPage.Controls.Add(this.InstallPackagesBtn);
            this.InstallPage.Controls.Add(this.PackagesGridView);
            this.InstallPage.Name = "InstallPage";
            this.InstallPage.UseVisualStyleBackColor = true;
            // 
            // CleanUpAutorunBox
            // 
            resources.ApplyResources(this.CleanUpAutorunBox, "CleanUpAutorunBox");
            this.CleanUpAutorunBox.Checked = true;
            this.CleanUpAutorunBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CleanUpAutorunBox.Name = "CleanUpAutorunBox";
            this.CleanUpAutorunBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // CleanInstallBox
            // 
            resources.ApplyResources(this.CleanInstallBox, "CleanInstallBox");
            this.CleanInstallBox.Name = "CleanInstallBox";
            this.CleanInstallBox.UseVisualStyleBackColor = true;
            // 
            // SelectBackupArchBtn
            // 
            resources.ApplyResources(this.SelectBackupArchBtn, "SelectBackupArchBtn");
            this.SelectBackupArchBtn.Name = "SelectBackupArchBtn";
            this.SelectBackupArchBtn.UseVisualStyleBackColor = true;
            this.SelectBackupArchBtn.Click += new System.EventHandler(this.SelectBackupArchBtn_Click);
            // 
            // RunPatchBtn
            // 
            resources.ApplyResources(this.RunPatchBtn, "RunPatchBtn");
            this.RunPatchBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.RunPatchBtn.Name = "RunPatchBtn";
            this.RunPatchBtn.UseVisualStyleBackColor = true;
            this.RunPatchBtn.Click += new System.EventHandler(this.RunPatchBtn_Click);
            // 
            // InstallPackagesBtn
            // 
            resources.ApplyResources(this.InstallPackagesBtn, "InstallPackagesBtn");
            this.InstallPackagesBtn.Name = "InstallPackagesBtn";
            this.InstallPackagesBtn.UseVisualStyleBackColor = true;
            this.InstallPackagesBtn.Click += new System.EventHandler(this.InstallPackagesBtn_Click);
            // 
            // PackagesGridView
            // 
            resources.ApplyResources(this.PackagesGridView, "PackagesGridView");
            this.PackagesGridView.AllowUserToAddRows = false;
            this.PackagesGridView.AllowUserToDeleteRows = false;
            this.PackagesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsPackageEnabledColumn,
            this.LoadOrderColumn,
            this.PackageNameColumn,
            this.PackageVersionColumn,
            this.PackageAuthorColumn,
            this.PackageDescriptionColumn});
            this.PackagesGridView.Name = "PackagesGridView";
            this.PackagesGridView.RowTemplate.Height = 24;
            this.PackagesGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PackagesGridView_CellFormatting);
            // 
            // IsPackageEnabledColumn
            // 
            resources.ApplyResources(this.IsPackageEnabledColumn, "IsPackageEnabledColumn");
            this.IsPackageEnabledColumn.Name = "IsPackageEnabledColumn";
            // 
            // LoadOrderColumn
            // 
            resources.ApplyResources(this.LoadOrderColumn, "LoadOrderColumn");
            this.LoadOrderColumn.Name = "LoadOrderColumn";
            this.LoadOrderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PackageNameColumn
            // 
            resources.ApplyResources(this.PackageNameColumn, "PackageNameColumn");
            this.PackageNameColumn.Name = "PackageNameColumn";
            this.PackageNameColumn.ReadOnly = true;
            // 
            // PackageVersionColumn
            // 
            resources.ApplyResources(this.PackageVersionColumn, "PackageVersionColumn");
            this.PackageVersionColumn.Name = "PackageVersionColumn";
            this.PackageVersionColumn.ReadOnly = true;
            // 
            // PackageAuthorColumn
            // 
            resources.ApplyResources(this.PackageAuthorColumn, "PackageAuthorColumn");
            this.PackageAuthorColumn.Name = "PackageAuthorColumn";
            this.PackageAuthorColumn.ReadOnly = true;
            // 
            // PackageDescriptionColumn
            // 
            resources.ApplyResources(this.PackageDescriptionColumn, "PackageDescriptionColumn");
            this.PackageDescriptionColumn.Name = "PackageDescriptionColumn";
            this.PackageDescriptionColumn.ReadOnly = true;
            // 
            // RandomPage
            // 
            resources.ApplyResources(this.RandomPage, "RandomPage");
            this.RandomPage.Controls.Add(this.ItemsCountBox);
            this.RandomPage.Controls.Add(this.label5);
            this.RandomPage.Controls.Add(this.ItemNamesBtn);
            this.RandomPage.Controls.Add(this.ItemModConfigsBtn);
            this.RandomPage.Controls.Add(this.BuildRandomItemsPackageBox);
            this.RandomPage.Controls.Add(this.ItemPriceRangeBox);
            this.RandomPage.Controls.Add(this.label6);
            this.RandomPage.Controls.Add(this.ProgressLabel);
            this.RandomPage.Controls.Add(this.GeneratorDataGrid);
            this.RandomPage.Controls.Add(this.GenerationProgressBar);
            this.RandomPage.Controls.Add(this.ConsoleTextBox);
            this.RandomPage.Controls.Add(this.GenerateBtn);
            this.RandomPage.Name = "RandomPage";
            this.RandomPage.UseVisualStyleBackColor = true;
            // 
            // ItemsCountBox
            // 
            resources.ApplyResources(this.ItemsCountBox, "ItemsCountBox");
            this.ItemsCountBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ItemsCountBox.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ItemsCountBox.Name = "ItemsCountBox";
            this.ItemsCountBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ItemsCountBox.ValueChanged += new System.EventHandler(this.ItemsCountBox_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // ItemNamesBtn
            // 
            resources.ApplyResources(this.ItemNamesBtn, "ItemNamesBtn");
            this.ItemNamesBtn.Name = "ItemNamesBtn";
            this.ItemNamesBtn.UseVisualStyleBackColor = true;
            this.ItemNamesBtn.Click += new System.EventHandler(this.ItemNamesBtn_Click);
            // 
            // ItemModConfigsBtn
            // 
            resources.ApplyResources(this.ItemModConfigsBtn, "ItemModConfigsBtn");
            this.ItemModConfigsBtn.Name = "ItemModConfigsBtn";
            this.ItemModConfigsBtn.UseVisualStyleBackColor = true;
            this.ItemModConfigsBtn.Click += new System.EventHandler(this.ItemModConfigsBtn_Click);
            // 
            // BuildRandomItemsPackageBox
            // 
            resources.ApplyResources(this.BuildRandomItemsPackageBox, "BuildRandomItemsPackageBox");
            this.BuildRandomItemsPackageBox.Checked = true;
            this.BuildRandomItemsPackageBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BuildRandomItemsPackageBox.Name = "BuildRandomItemsPackageBox";
            this.BuildRandomItemsPackageBox.UseVisualStyleBackColor = true;
            this.BuildRandomItemsPackageBox.CheckedChanged += new System.EventHandler(this.BuildRandomItemsPackageBox_CheckedChanged);
            // 
            // ItemPriceRangeBox
            // 
            resources.ApplyResources(this.ItemPriceRangeBox, "ItemPriceRangeBox");
            this.ItemPriceRangeBox.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.ItemPriceRangeBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ItemPriceRangeBox.Name = "ItemPriceRangeBox";
            this.ItemPriceRangeBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ItemPriceRangeBox.ValueChanged += new System.EventHandler(this.ItemPriceRangeBox_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ProgressLabel
            // 
            resources.ApplyResources(this.ProgressLabel, "ProgressLabel");
            this.ProgressLabel.Name = "ProgressLabel";
            // 
            // GeneratorDataGrid
            // 
            resources.ApplyResources(this.GeneratorDataGrid, "GeneratorDataGrid");
            this.GeneratorDataGrid.AllowUserToAddRows = false;
            this.GeneratorDataGrid.AllowUserToDeleteRows = false;
            this.GeneratorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GeneratorDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsActiveColumn,
            this.SchemaNameColumn,
            this.QuantityColumn,
            this.ModsMinColumn,
            this.ModsMaxColumn,
            this.PowerColumn,
            this.CondPower,
            this.DamagePower,
            this.RangePower,
            this.ProtPower,
            this.PotionDurationPower,
            this.PriceColumn,
            this.ItemNameColumn,
            this.UseUniqNameColumn,
            this.SeedColumn});
            this.GeneratorDataGrid.Name = "GeneratorDataGrid";
            this.GeneratorDataGrid.RowTemplate.Height = 24;
            this.GeneratorDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GeneratorDataGrid_CellFormatting);
            // 
            // IsActiveColumn
            // 
            resources.ApplyResources(this.IsActiveColumn, "IsActiveColumn");
            this.IsActiveColumn.Name = "IsActiveColumn";
            // 
            // SchemaNameColumn
            // 
            resources.ApplyResources(this.SchemaNameColumn, "SchemaNameColumn");
            this.SchemaNameColumn.Name = "SchemaNameColumn";
            this.SchemaNameColumn.ReadOnly = true;
            // 
            // QuantityColumn
            // 
            resources.ApplyResources(this.QuantityColumn, "QuantityColumn");
            this.QuantityColumn.Name = "QuantityColumn";
            // 
            // ModsMinColumn
            // 
            resources.ApplyResources(this.ModsMinColumn, "ModsMinColumn");
            this.ModsMinColumn.Name = "ModsMinColumn";
            // 
            // ModsMaxColumn
            // 
            resources.ApplyResources(this.ModsMaxColumn, "ModsMaxColumn");
            this.ModsMaxColumn.Name = "ModsMaxColumn";
            // 
            // PowerColumn
            // 
            resources.ApplyResources(this.PowerColumn, "PowerColumn");
            this.PowerColumn.Name = "PowerColumn";
            // 
            // CondPower
            // 
            resources.ApplyResources(this.CondPower, "CondPower");
            this.CondPower.Name = "CondPower";
            // 
            // DamagePower
            // 
            resources.ApplyResources(this.DamagePower, "DamagePower");
            this.DamagePower.Name = "DamagePower";
            // 
            // RangePower
            // 
            resources.ApplyResources(this.RangePower, "RangePower");
            this.RangePower.Name = "RangePower";
            // 
            // ProtPower
            // 
            resources.ApplyResources(this.ProtPower, "ProtPower");
            this.ProtPower.Name = "ProtPower";
            // 
            // PotionDurationPower
            // 
            resources.ApplyResources(this.PotionDurationPower, "PotionDurationPower");
            this.PotionDurationPower.Name = "PotionDurationPower";
            // 
            // PriceColumn
            // 
            resources.ApplyResources(this.PriceColumn, "PriceColumn");
            this.PriceColumn.Name = "PriceColumn";
            // 
            // ItemNameColumn
            // 
            resources.ApplyResources(this.ItemNameColumn, "ItemNameColumn");
            this.ItemNameColumn.Name = "ItemNameColumn";
            // 
            // UseUniqNameColumn
            // 
            resources.ApplyResources(this.UseUniqNameColumn, "UseUniqNameColumn");
            this.UseUniqNameColumn.Name = "UseUniqNameColumn";
            // 
            // SeedColumn
            // 
            resources.ApplyResources(this.SeedColumn, "SeedColumn");
            this.SeedColumn.Name = "SeedColumn";
            this.SeedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GenerationProgressBar
            // 
            resources.ApplyResources(this.GenerationProgressBar, "GenerationProgressBar");
            this.GenerationProgressBar.Name = "GenerationProgressBar";
            // 
            // ConsoleTextBox
            // 
            resources.ApplyResources(this.ConsoleTextBox, "ConsoleTextBox");
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            // 
            // GenerateBtn
            // 
            resources.ApplyResources(this.GenerateBtn, "GenerateBtn");
            this.GenerateBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // ModConfigsPage
            // 
            resources.ApplyResources(this.ModConfigsPage, "ModConfigsPage");
            this.ModConfigsPage.Controls.Add(this.ModConfigsTextBox);
            this.ModConfigsPage.Name = "ModConfigsPage";
            this.ModConfigsPage.UseVisualStyleBackColor = true;
            // 
            // ModConfigsTextBox
            // 
            resources.ApplyResources(this.ModConfigsTextBox, "ModConfigsTextBox");
            this.ModConfigsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModConfigsTextBox.Name = "ModConfigsTextBox";
            this.ModConfigsTextBox.TextChanged += new System.EventHandler(this.ModConfigsTextBox_TextChanged);
            // 
            // AppConfigsPage
            // 
            resources.ApplyResources(this.AppConfigsPage, "AppConfigsPage");
            this.AppConfigsPage.Controls.Add(this.linkLabel3);
            this.AppConfigsPage.Controls.Add(this.linkLabel2);
            this.AppConfigsPage.Controls.Add(this.label8);
            this.AppConfigsPage.Controls.Add(this.OutputFilesCodepageBox);
            this.AppConfigsPage.Controls.Add(this.label4);
            this.AppConfigsPage.Controls.Add(this.VdfsArchiveBox);
            this.AppConfigsPage.Controls.Add(this.label10);
            this.AppConfigsPage.Controls.Add(this.linkLabel1);
            this.AppConfigsPage.Controls.Add(this.label7);
            this.AppConfigsPage.Controls.Add(this.LanguageSelectBox);
            this.AppConfigsPage.Controls.Add(this.label2);
            this.AppConfigsPage.Controls.Add(this.SetGothicDirBtn);
            this.AppConfigsPage.Controls.Add(this.GamePathTextBox);
            this.AppConfigsPage.Controls.Add(this.label1);
            this.AppConfigsPage.Name = "AppConfigsPage";
            this.AppConfigsPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // OutputFilesCodepageBox
            // 
            resources.ApplyResources(this.OutputFilesCodepageBox, "OutputFilesCodepageBox");
            this.OutputFilesCodepageBox.FormattingEnabled = true;
            this.OutputFilesCodepageBox.Items.AddRange(new object[] {
            resources.GetString("OutputFilesCodepageBox.Items"),
            resources.GetString("OutputFilesCodepageBox.Items1")});
            this.OutputFilesCodepageBox.Name = "OutputFilesCodepageBox";
            this.OutputFilesCodepageBox.SelectedIndexChanged += new System.EventHandler(this.OutputFilesCodepageBox_SelectedIndexChanged);
            this.OutputFilesCodepageBox.TextUpdate += new System.EventHandler(this.OutputFilesCodepageBox_TextUpdate);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // VdfsArchiveBox
            // 
            resources.ApplyResources(this.VdfsArchiveBox, "VdfsArchiveBox");
            this.VdfsArchiveBox.Name = "VdfsArchiveBox";
            this.VdfsArchiveBox.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // LanguageSelectBox
            // 
            resources.ApplyResources(this.LanguageSelectBox, "LanguageSelectBox");
            this.LanguageSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageSelectBox.FormattingEnabled = true;
            this.LanguageSelectBox.Items.AddRange(new object[] {
            resources.GetString("LanguageSelectBox.Items"),
            resources.GetString("LanguageSelectBox.Items1")});
            this.LanguageSelectBox.Name = "LanguageSelectBox";
            this.LanguageSelectBox.SelectedIndexChanged += new System.EventHandler(this.LanguageSelectBox_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // SetGothicDirBtn
            // 
            resources.ApplyResources(this.SetGothicDirBtn, "SetGothicDirBtn");
            this.SetGothicDirBtn.Name = "SetGothicDirBtn";
            this.SetGothicDirBtn.UseVisualStyleBackColor = true;
            this.SetGothicDirBtn.Click += new System.EventHandler(this.SetGothicDirBtn_Click);
            // 
            // GamePathTextBox
            // 
            resources.ApplyResources(this.GamePathTextBox, "GamePathTextBox");
            this.GamePathTextBox.Name = "GamePathTextBox";
            this.GamePathTextBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DirBrowserDialog
            // 
            resources.ApplyResources(this.DirBrowserDialog, "DirBrowserDialog");
            // 
            // PackageListUpdater
            // 
            this.PackageListUpdater.Interval = 2500;
            this.PackageListUpdater.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FileOpenDialog
            // 
            this.FileOpenDialog.DefaultExt = " \"Vdf files|*.vdf|Mod files (*.mod*)|*.mod*\"";
            this.FileOpenDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.FileOpenDialog, "FileOpenDialog");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabsPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabsPanel.ResumeLayout(false);
            this.InstallPage.ResumeLayout(false);
            this.InstallPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackagesGridView)).EndInit();
            this.RandomPage.ResumeLayout(false);
            this.RandomPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPriceRangeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDataGrid)).EndInit();
            this.ModConfigsPage.ResumeLayout(false);
            this.AppConfigsPage.ResumeLayout(false);
            this.AppConfigsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabsPanel;
        private System.Windows.Forms.TabPage InstallPage;
        private System.Windows.Forms.TabPage RandomPage;
        private System.Windows.Forms.TabPage AppConfigsPage;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.TextBox GamePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetGothicDirBtn;
        private System.Windows.Forms.ComboBox LanguageSelectBox;
        private System.Windows.Forms.FolderBrowserDialog DirBrowserDialog;
        private System.Windows.Forms.RichTextBox ConsoleTextBox;
        private System.Windows.Forms.ProgressBar GenerationProgressBar;
        private System.Windows.Forms.DataGridView GeneratorDataGrid;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.TabPage ModConfigsPage;
        private System.Windows.Forms.RichTextBox ModConfigsTextBox;
        private System.Windows.Forms.NumericUpDown ItemPriceRangeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView PackagesGridView;
        private System.Windows.Forms.Button InstallPackagesBtn;
        private System.Windows.Forms.Button RunPatchBtn;
        private System.Windows.Forms.CheckBox BuildRandomItemsPackageBox;
        private System.Windows.Forms.Timer PackageListUpdater;
        private System.Windows.Forms.Button ItemModConfigsBtn;
        private System.Windows.Forms.TextBox VdfsArchiveBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog FileOpenDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPackageEnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadOrderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageVersionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageAuthorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageDescriptionColumn;
        private System.Windows.Forms.Button ItemNamesBtn;
        private System.Windows.Forms.CheckBox CleanInstallBox;
        private System.Windows.Forms.Button SelectBackupArchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CleanUpAutorunBox;
        private System.Windows.Forms.ComboBox OutputFilesCodepageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ItemsCountBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActiveColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchemaNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModsMinColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModsMaxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PowerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamagePower;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangePower;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProtPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn PotionDurationPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseUniqNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeedColumn;
    }
}

