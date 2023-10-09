namespace MagicBalanceConfigurator
{
    partial class ModsConfigsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemModsGridView = new System.Windows.Forms.DataGridView();
            this.ModNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModMinValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModMaxValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModRarityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsModEnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemModsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemModsGridView
            // 
            this.ItemModsGridView.AllowUserToAddRows = false;
            this.ItemModsGridView.AllowUserToDeleteRows = false;
            this.ItemModsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemModsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModNameColumn,
            this.ModMinValueColumn,
            this.ModMaxValueColumn,
            this.ModRarityColumn,
            this.IsModEnabledColumn});
            this.ItemModsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemModsGridView.Location = new System.Drawing.Point(0, 0);
            this.ItemModsGridView.Name = "ItemModsGridView";
            this.ItemModsGridView.Size = new System.Drawing.Size(584, 361);
            this.ItemModsGridView.TabIndex = 0;
            this.ItemModsGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ItemModsGridView_CellFormatting);
            // 
            // ModNameColumn
            // 
            this.ModNameColumn.HeaderText = "Name";
            this.ModNameColumn.MinimumWidth = 150;
            this.ModNameColumn.Name = "ModNameColumn";
            this.ModNameColumn.ReadOnly = true;
            this.ModNameColumn.Width = 200;
            // 
            // ModMinValueColumn
            // 
            this.ModMinValueColumn.HeaderText = "Min. value";
            this.ModMinValueColumn.MinimumWidth = 80;
            this.ModMinValueColumn.Name = "ModMinValueColumn";
            this.ModMinValueColumn.Width = 80;
            // 
            // ModMaxValueColumn
            // 
            this.ModMaxValueColumn.HeaderText = "Max. value";
            this.ModMaxValueColumn.MinimumWidth = 80;
            this.ModMaxValueColumn.Name = "ModMaxValueColumn";
            this.ModMaxValueColumn.Width = 80;
            // 
            // ModRarityColumn
            // 
            this.ModRarityColumn.HeaderText = "Rarity (%)";
            this.ModRarityColumn.MinimumWidth = 80;
            this.ModRarityColumn.Name = "ModRarityColumn";
            this.ModRarityColumn.Width = 80;
            // 
            // IsModEnabledColumn
            // 
            this.IsModEnabledColumn.HeaderText = "Enabled";
            this.IsModEnabledColumn.MinimumWidth = 80;
            this.IsModEnabledColumn.Name = "IsModEnabledColumn";
            this.IsModEnabledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsModEnabledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsModEnabledColumn.Width = 80;
            // 
            // ModsConfigsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.ItemModsGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ModsConfigsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Random Items mods";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModsConfigsWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ItemModsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemModsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModMinValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModMaxValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModRarityColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsModEnabledColumn;
    }
}