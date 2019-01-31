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
    public partial class YesNoBox : Form
    {
        public static DialogResult Show(string text, string title = "")
        {
            return new YesNoBox(text, title).ShowDialog();
        }

        public YesNoBox(string text, string title)
        {
            InitializeComponent();

            Text = title;
            labText.Text = text;

            if (labText.Size.Width > Size.Width)
            {
                Size = new Size(labText.Size.Width + 13 * 3, Size.Height);
            }
        }

        private void ConfirmBox_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            Close();
        }
    }
}
