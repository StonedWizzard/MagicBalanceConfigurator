using MagicBalanceConfigurator.Generators;
using System;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public partial class ModsConfigsWindow : Form
    {
        public ModsConfigsWindow()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            foreach (var mod in ItemModsProvider.ItemMods)
            {
                var row = mod.GetData();
                ItemModsGridView.Rows.Add(row);
            };
        }

        private object TrySetValue(object value, object backUp, Func<object> act)
        {
            if (value == null) return backUp;
            try { value = act.Invoke(); }
            catch { value = backUp; }
            return value;
        }

        private void ItemModsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string name = ItemModsGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            var mod = ItemModsProvider.GetModByName(name);
            if (mod == null) return;

            if (ItemModsGridView.Columns[e.ColumnIndex].Name == "IsModEnabledColumn")
                e.Value = TrySetValue(e.Value, mod.IsEnabled, () => {
                    mod.IsEnabled = Convert.ToBoolean(e.Value);
                    return mod.IsEnabled;
                });

            if (ItemModsGridView.Columns[e.ColumnIndex].Name == "ModMinValueColumn")
            {
                e.Value = TrySetValue(e.Value, mod.ValueMin, () =>
                {
                    mod.ValueMin = Convert.ToInt32(e.Value);
                    mod.SetValueRange(mod.ValueMin, mod.ValueMax);
                    return mod.ValueMin;
                });
            }
            if (ItemModsGridView.Columns[e.ColumnIndex].Name == "ModMaxValueColumn")
            {
                e.Value = TrySetValue(e.Value, mod.ValueMax, () =>
                {
                    mod.ValueMax = Convert.ToInt32(e.Value);
                    mod.SetValueRange(mod.ValueMin, mod.ValueMax);
                    return mod.ValueMax;
                });
            }
            if (ItemModsGridView.Columns[e.ColumnIndex].Name == "ModRarityColumn")
            {
                e.Value = TrySetValue(e.Value, mod.ModRarity, () =>
                {
                    mod.ModRarity = Convert.ToInt32(e.Value);
                    return mod.ModRarity;
                });
            }
            ItemModsProvider.UpdateItemsMods();
        }

        private void ModsConfigsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ItemModsProvider.UpdateItemsMods();
        }
    }
}
