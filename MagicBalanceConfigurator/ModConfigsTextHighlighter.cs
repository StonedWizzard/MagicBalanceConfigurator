using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public partial class MainForm : Form
    {
        class ModConfigsTextHighlighter
        {
            private const string KeywordsTemplate =
                @"\b(class|instance|func|var|true|false|META|return)\b";
            private const string TypesTemplate =
                @"\b(int|void|string|float|self|other|hero)\b";
            private const string CommentsTemplates = @"(\/\/.+?$|\/\*.+?\*\/)";
            private const string StringsTemplate = "\".+?\"";

            private RichTextBox TextBox;
            public ModConfigsTextHighlighter(RichTextBox textBox)
            {
                TextBox = textBox;
                TextBox.TextChanged += TextChanged;
            }

            private void TextChanged(object sender, EventArgs e)
            {
                MatchCollection keywordMatches = Regex.Matches(TextBox.Text, KeywordsTemplate);
                MatchCollection typeMatches = Regex.Matches(TextBox.Text, TypesTemplate);
                MatchCollection commentMatches = Regex.Matches(TextBox.Text, CommentsTemplates, RegexOptions.Multiline);
                MatchCollection stringMatches = Regex.Matches(TextBox.Text, StringsTemplate);

                int originalIndex = TextBox.SelectionStart;
                int originalLength = TextBox.SelectionLength;
                Color originalColor = Color.Black;

                TextBox.Enabled = false;
                TextBox.SelectionStart = 0;
                TextBox.SelectionLength = TextBox.Text.Length;
                TextBox.SelectionColor = originalColor;

                HiglightKewords(keywordMatches);
                HiglightTypes(typeMatches);
                HiglightComments(commentMatches);
                HiglightStrings(stringMatches);

                TextBox.SelectionStart = originalIndex;
                TextBox.SelectionLength = originalLength;
                TextBox.SelectionColor = originalColor;
                TextBox.Enabled = true;
                TextBox.Focus();
            }

            private void HiglightKewords(MatchCollection items)
            {
                foreach (Match m in items)
                {
                    TextBox.SelectionStart = m.Index;
                    TextBox.SelectionLength = m.Length;
                    TextBox.SelectionColor = Color.Blue;
                }
            }

            private void HiglightTypes(MatchCollection items)
            {
                foreach (Match m in items)
                {
                    TextBox.SelectionStart = m.Index;
                    TextBox.SelectionLength = m.Length;
                    TextBox.SelectionColor = Color.DarkCyan;
                }
            }

            private void HiglightComments(MatchCollection items)
            {
                foreach (Match m in items)
                {
                    TextBox.SelectionStart = m.Index;
                    TextBox.SelectionLength = m.Length;
                    TextBox.SelectionColor = Color.Green;
                }
            }

            private void HiglightStrings(MatchCollection items)
            {
                foreach (Match m in items)
                {
                    TextBox.SelectionStart = m.Index;
                    TextBox.SelectionLength = m.Length;
                    TextBox.SelectionColor = Color.Brown;
                }
            }
        }
    }
}
