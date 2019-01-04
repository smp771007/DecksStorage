using DecksStorage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksStorage
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateForm_Load(object sender, EventArgs e)
        {
            //更新模式選框
            cbFormat.Items.Clear();
            cbFormat.Items.Add("");
            cbFormat.Items.AddRange(DataHelper.Decks.Select(x => x.Format).Distinct().Cast<object>().ToArray());

            //更新職業選框
            cbClass.Items.Clear();
            cbClass.Items.Add("");
            cbClass.Items.AddRange(DataHelper.Decks.Select(x => x.Class).Distinct().Cast<object>().ToArray());

            //從剪貼簿複製資料
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
            {
                rtbContent.Text = data.GetData(DataFormats.Text).ToString();
            }
        }

        /// <summary>
        /// 解析牌組代碼
        /// </summary>
        /// <param name="content"></param>
        private void Analysis(string content)
        {
            //1:Name(名稱), 2:Class(職業), 3:Format(模式)
            var match = Regex.Match(content, "###(.*)\n# (?:.*: )(.*)\n# (?:.*: )(.*)\n");

            if (!match.Success) return;

            txtName.Text = match.Groups[1].Value;
            cbClass.Text = match.Groups[2].Value;
            cbFormat.Text = match.Groups[3].Value;
        }

        /// <summary>
        /// 儲存新牌組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            DataHelper.AddDeck(new Deck
            {
                Name = txtName.Text,
                Class = cbClass.Text,
                Format = cbFormat.Text,
                Content = rtbContent.Text,
                Note = txtNote.Text
            });

            Close();
        }

        /// <summary>
        /// 牌組內容變更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtbContent_TextChanged(object sender, EventArgs e)
        {
            Analysis(rtbContent.Text);
        }
    }
}
