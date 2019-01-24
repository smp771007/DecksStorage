using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksStorage
{
    public partial class ReplaceForm : Form
    {
        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "全部", Value = ReplaceItem.All });
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "名稱", Value = ReplaceItem.Name });
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "模式", Value = ReplaceItem.Format });
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "職業", Value = ReplaceItem.Class });
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "分類", Value = ReplaceItem.Category });
            cbReplaceArea.Items.Add(new ComboboxItem { Text = "備註", Value = ReplaceItem.Note });

            cbReplaceArea.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            var from = txtFrom.Text;
            var to = txtTo.Text;

            var count = 0;

            if (!string.IsNullOrEmpty(from))
            {
                foreach (var decks in DataHelper.Decks)
                {
                    switch (((ComboboxItem)cbReplaceArea.SelectedItem).Value)
                    {
                        case ReplaceItem.All:
                            count += $"{decks.Name}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            count += $"{decks.Format}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            count += $"{decks.Class}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            count += $"{decks.Category}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            count += $"{decks.Note}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Name = decks.Name?.Replace(from, to);
                            decks.Format = decks.Format?.Replace(from, to);
                            decks.Class = decks.Class?.Replace(from, to);
                            decks.Category = decks.Category?.Replace(from, to);
                            decks.Note = decks.Note?.Replace(from, to);
                            break;
                        case ReplaceItem.Name:
                            count += $"{decks.Name}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Name = decks.Name?.Replace(from, to);
                            break;
                        case ReplaceItem.Format:
                            count += $"{decks.Format}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Format = decks.Format?.Replace(from, to);
                            break;
                        case ReplaceItem.Class:
                            count += $"{decks.Class}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Class = decks.Class?.Replace(from, to);
                            break;
                        case ReplaceItem.Category:
                            count += $"{decks.Category}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Category = decks.Category?.Replace(from, to);
                            break;
                        case ReplaceItem.Note:
                            count += $"{decks.Note}".Split(new string[] { from }, StringSplitOptions.None).Length - 1;
                            decks.Note = decks.Note?.Replace(from, to);
                            break;
                    }
                }
            }

            lbReplaceResult.Text = $"共取代了{count}個項目。";

            DataHelper.UpdateDeck(MainForm.ReflashType.Keep);
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public ReplaceItem Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public enum ReplaceItem
        {
            All, Name, Format, Class, Category, Note
        }
    }
}
