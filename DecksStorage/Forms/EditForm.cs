using DecksStorage.Models;
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
    public partial class EditForm : Form
    {
        private int _index;
        private Deck _deck;

        public EditForm(int rowIndex, Deck deck)
        {
            InitializeComponent();

            _index = rowIndex;
            _deck = deck;

            txtName.Text = deck.Name;
            cbClass.Text = deck.Class;
            cbFormat.Text = deck.Format;
            cbCategory.Text = deck.Category;
            txtNote.Text = deck.Note;
            rtbContent.Text = deck.Content;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _deck.Name = txtName.Text;
            _deck.Class = cbClass.Text;
            _deck.Format = cbFormat.Text;
            _deck.Category = cbCategory.Text;
            _deck.Note = txtNote.Text;
            _deck.Content = rtbContent.Text;

            DataHelper.UpdateDeck(MainForm.ReflashType.Keep);

            Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            //更新職業選框
            cbClass.Items.Clear();
            cbClass.Items.Add("");
            cbClass.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Class))
                .Select(x => x.Class).Distinct().OrderBy(x => x).Cast<object>().ToArray());

            //更新模式選框
            cbFormat.Items.Clear();
            cbFormat.Items.Add("");
            cbFormat.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Format))
                .Select(x => x.Format).Distinct().OrderBy(x => x).Cast<object>().ToArray());

            //更新分類選框
            cbCategory.Items.Clear();
            cbCategory.Items.Add("");
            cbCategory.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Category))
                .Select(x => x.Category).Distinct().OrderBy(x => x).Cast<object>().ToArray());
        }
    }
}
