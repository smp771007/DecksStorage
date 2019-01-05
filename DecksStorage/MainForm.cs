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
    public partial class MainForm : Form
    {
        private int _deckTableSortIndex = -1;
        private bool _deckTableReverse = true;

        public static MainForm Self { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = $"牌組儲藏室 {Settings.Version}";

            //設定視窗位置
            AuthResizeFormTool.Set(
                this,
                Properties.Settings.Default.MFSize,
                Properties.Settings.Default.MFState,
                Properties.Settings.Default.MFLocation);

            Self = this;

            UpdateView();
        }

        /// <summary>
        /// Form Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var output = AuthResizeFormTool.Get(this);
            Properties.Settings.Default.MFState = output.State;
            Properties.Settings.Default.MFLocation = output.Location;
            Properties.Settings.Default.MFSize = output.Size;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 更新顯示
        /// </summary>
        public void UpdateView()
        {
            //更新模式選框
            var selected = cbSearchFormat.Text;
            cbSearchFormat.Items.Clear();
            cbSearchFormat.Items.Add("");
            cbSearchFormat.Items.AddRange(DataHelper.Decks.Select(x => x.Format).Distinct().Cast<object>().ToArray());
            cbSearchFormat.Text = selected;

            //更新職業選框
            selected = cbSearchClass.Text;
            cbSearchClass.Items.Clear();
            cbSearchClass.Items.Add("");
            cbSearchClass.Items.AddRange(DataHelper.Decks.Select(x => x.Class).Distinct().Cast<object>().ToArray());
            cbSearchClass.Text = selected;

            //更新牌組表單顯示
            UpdateDeckView();
        }

        /// <summary>
        /// 更新牌組表單顯示
        /// </summary>
        private void UpdateDeckView()
        {
            var binding = new BindingSource
            {
                DataSource = DataHelper.Decks
                .Where(x => x.Name.IndexOf(txtSearchName.Text, StringComparison.OrdinalIgnoreCase) >= 0) //名稱
                .Where(x => string.IsNullOrEmpty(cbSearchFormat.Text) ? true : x.Format == cbSearchFormat.Text) //模式
                .Where(x => string.IsNullOrEmpty(cbSearchClass.Text) ? true : x.Class == cbSearchClass.Text) //職業
                .Where(x => x.Note.IndexOf(txtSearchNote.Text, StringComparison.OrdinalIgnoreCase) >= 0) //備註
                .ToList()
            };

            dgvDeck.DataSource = binding;
        }

        /// <summary>
        /// 開啟新增牌組Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCreate_Click(object sender, EventArgs e)
        {
            var form = new CreateForm();
            form.ShowDialog(this);
        }

        /// <summary>
        /// 牌組列表點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDeck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //標頭
            if (e.RowIndex == -1)
            {
                DecksSort(e);
                return;
            };

            var deck = (Deck)dgvDeck.Rows[e.RowIndex].DataBoundItem;

            switch ((DeckTableColumns)e.ColumnIndex)
            {
                case DeckTableColumns.Copy: //複製
                    Clipboard.SetData(DataFormats.Text, deck.Content);
                    break;
                case DeckTableColumns.Delete: //刪除
                    DeleteDeck(deck);
                    break;
            }
        }

        /// <summary>
        /// 牌組排序
        /// </summary>
        /// <param name="e"></param>
        private void DecksSort(DataGridViewCellEventArgs e)
        {
            if (_deckTableSortIndex == e.ColumnIndex)
            {
                _deckTableReverse = !_deckTableReverse;
            }
            else
            {
                _deckTableReverse = true;
            }

            _deckTableSortIndex = e.ColumnIndex;

            for (int i = 0; i < dgvDeck.ColumnCount; i++)
            {
                dgvDeck.Columns[i].HeaderText = string.Join("", dgvDeck.Columns[i].HeaderText.Where(x => x != '▼' && x != '▲'));

                if (i == e.ColumnIndex)
                {
                    dgvDeck.Columns[i].HeaderText += _deckTableReverse ? "▼" : "▲";
                }
            }

            switch ((DeckTableColumns)e.ColumnIndex)
            {
                case DeckTableColumns.Name: //名稱
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Name).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Name).ToList();
                    break;
                case DeckTableColumns.Format: //模式
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Format).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Format).ToList();
                    break;
                case DeckTableColumns.Class: //職業
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Class).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Class).ToList();
                    break;
                case DeckTableColumns.Note: //備註
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Note).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Note).ToList();
                    break;
                default:
                    return;
            }

            DataHelper.UpdateDeck();
        }

        /// <summary>
        /// 刪除牌組
        /// </summary>
        /// <param name="deck"></param>
        private void DeleteDeck(Deck deck)
        {

            var confirmResult = MessageBox.Show($"確定要刪除此牌組({deck.Name})?", "刪除", MessageBoxButtons.YesNo);

            if (confirmResult != DialogResult.Yes) return;

            DataHelper.DeleteDeck(deck);
        }

        /// <summary>
        /// 清空所有牌組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClearDecks_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"確定要清空所有牌組資訊嗎?", "刪除", MessageBoxButtons.YesNo);

            DataHelper.DeleteAllDeck();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            UpdateDeckView();
        }

        private void cbSearchClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeckView();
        }

        private void cbSearchFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeckView();
        }

        private void txtSearchNote_TextChanged(object sender, EventArgs e)
        {
            UpdateDeckView();
        }

        private enum DeckTableColumns
        {
            /// <summary>
            /// 名稱
            /// </summary>
            Name,
            /// <summary>
            /// 模式
            /// </summary>
            Format,
            /// <summary>
            /// 職業
            /// </summary>
            Class,
            /// <summary>
            /// 備註
            /// </summary>
            Note,
            /// <summary>
            /// 複製
            /// </summary>
            Copy,
            /// <summary>
            /// 刪除
            /// </summary>
            Delete
        }
    }
}
