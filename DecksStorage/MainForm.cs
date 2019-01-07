using DecksStorage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <param name="clearSort">清除排序</param>
        public void UpdateView(bool clearSort = false)
        {
            string selected;

            if (clearSort) ClearSort(true);

            //更新職業選框
            selected = cbSearchClass.Text;
            cbSearchClass.Items.Clear();
            cbSearchClass.Items.Add("");
            cbSearchClass.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Class))
                .Select(x => x.Class).Distinct().OrderBy(x => x).Cast<object>().ToArray());
            cbSearchClass.Text = selected;

            //更新模式選框
            selected = cbSearchFormat.Text;
            cbSearchFormat.Items.Clear();
            cbSearchFormat.Items.Add("");
            cbSearchFormat.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Format))
                .Select(x => x.Format).Distinct().OrderBy(x => x).Cast<object>().ToArray());
            cbSearchFormat.Text = selected;

            //更新分類選框
            selected = cbSearchCategory.Text;
            cbSearchCategory.Items.Clear();
            cbSearchCategory.Items.Add("");
            cbSearchCategory.Items.AddRange(DataHelper.Decks.Where(x => !string.IsNullOrEmpty(x.Category))
                .Select(x => x.Category).Distinct().OrderBy(x => x).Cast<object>().ToArray());
            cbSearchCategory.Text = selected;

            //更新牌組表單顯示
            UpdateDeckView();
        }

        /// <summary>
        /// 更新牌組表單顯示
        /// </summary>
        private void UpdateDeckView()
        {
            var source = DataHelper.Decks
                .Where(x => x.Name.IndexOf(txtSearchName.Text, StringComparison.OrdinalIgnoreCase) >= 0) //名稱
                .Where(x => string.IsNullOrEmpty(cbSearchClass.Text) ? true : x.Class == cbSearchClass.Text) //職業
                .Where(x => string.IsNullOrEmpty(cbSearchFormat.Text) ? true : x.Format == cbSearchFormat.Text) //模式
                .Where(x => string.IsNullOrEmpty(cbSearchCategory.Text) ? true : x.Category == cbSearchCategory.Text) //分類
                .Where(x => x.Note.IndexOf(txtSearchNote.Text, StringComparison.OrdinalIgnoreCase) >= 0) //備註
                .ToList();


            lbDeckCount.Text = $"牌組數量: {source.Count}";

            dgvDeck.DataSource = new BindingSource
            {
                DataSource = source
            }; ;
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
                case DeckTableColumns.Edit: //修改
                    var form = new EditForm(e.RowIndex, deck);
                    form.ShowDialog(this);
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
            //按鈕不排序
            switch ((DeckTableColumns)e.ColumnIndex)
            {
                case DeckTableColumns.Copy:
                case DeckTableColumns.Edit:
                case DeckTableColumns.Delete:
                    return;
            }

            ClearSort();

            //處理正反排序
            if (_deckTableSortIndex == e.ColumnIndex)
            {
                _deckTableReverse = !_deckTableReverse;
            }
            else
            {
                _deckTableReverse = true;
            }

            _deckTableSortIndex = e.ColumnIndex;

            dgvDeck.Columns[e.ColumnIndex].HeaderText += _deckTableReverse ? "▼" : "▲";

            switch ((DeckTableColumns)e.ColumnIndex)
            {
                case DeckTableColumns.Name: //名稱
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Name).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Name).ToList();
                    break;
                case DeckTableColumns.Class: //職業
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Class).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Class).ToList();
                    break;
                case DeckTableColumns.Format: //模式
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Format).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Format).ToList();
                    break;
                case DeckTableColumns.Category: //模式
                    DataHelper.Decks = _deckTableReverse ?
                        DataHelper.Decks.OrderByDescending(x => x.Category).ToList() :
                        DataHelper.Decks.OrderBy(x => x.Category).ToList();
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
        /// 清除排序
        /// </summary>
        /// <param name="reset"></param>
        private void ClearSort(bool reset = false)
        {
            for (int i = 0; i < dgvDeck.ColumnCount; i++)
            {
                dgvDeck.Columns[i].HeaderText = string.Join("", dgvDeck.Columns[i].HeaderText.Where(x => x != '▼' && x != '▲'));
            }

            if (reset)
            {
                _deckTableSortIndex = -1;
                _deckTableReverse = true;
            }
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

            if (confirmResult != DialogResult.Yes) return;

            DataHelper.DeleteAllDeck();
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            UpdateDeckView();
        }

        /// <summary>
        /// 清空查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            cbSearchClass.Text = "";
            cbSearchFormat.Text = "";
            cbSearchCategory.Text = "";
            txtSearchNote.Text = "";
        }

        /// <summary>
        /// 匯入牌組檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "爐石牌組檔(.ds)|*.ds"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var decks = File.ReadAllText(dialog.FileName);

            try
            {
                DataHelper.Import(decks);
            }
            catch
            {
                MessageBox.Show("匯入失敗");
            }
        }

        /// <summary>
        /// 匯出牌組檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "爐石牌組檔(.ds)|*.ds"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllText(dialog.FileName, Properties.Settings.Default.Decks);

            MessageBox.Show("匯出完成");
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ReplaceForm();
            form.ShowDialog(this);
        }

        public enum DeckTableColumns
        {
            /// <summary>
            /// 複製
            /// </summary>
            Copy,
            /// <summary>
            /// 名稱
            /// </summary>
            Name,
            /// <summary>
            /// 職業
            /// </summary>
            Class,
            /// <summary>
            /// 模式
            /// </summary>
            Format,
            /// <summary>
            /// 分類
            /// </summary>
            Category,
            /// <summary>
            /// 備註
            /// </summary>
            Note,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 刪除
            /// </summary>
            Delete
        }
    }
}
