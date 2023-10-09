using MagicBalanceConfigurator.Generators;
using System;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public partial class ItemNamesWindow : Form
    {
        public ItemNamesWindow()
        {
            InitializeComponent();
            AfixesTextBox.Text = ItemModsProvider.ItemsAfixes.ParseArrayToString();
            SufixesTextBox.Text = ItemModsProvider.ItemsSufixes.ParseArrayToString();
            PrefixesTextBox.Text = ItemModsProvider.ItemsPrefixes.ParseArrayToString();
        }

        private void PrefixesTextBox_TextChanged(object sender, EventArgs e)
        {
            ItemModsProvider.ItemsPrefixes = PrefixesTextBox.Text.ParseStringToArray();
            ItemModsProvider.UpdateItemsMods();
        }

        private void AfixesTextBox_TextChanged(object sender, EventArgs e)
        {
            ItemModsProvider.ItemsAfixes = AfixesTextBox.Text.ParseStringToArray();
            ItemModsProvider.UpdateItemsMods();
        }

        private void SufixesTextBox_TextChanged(object sender, EventArgs e)
        {
            ItemModsProvider.ItemsSufixes = SufixesTextBox.Text.ParseStringToArray();
            ItemModsProvider.UpdateItemsMods();
        }
    }
}
