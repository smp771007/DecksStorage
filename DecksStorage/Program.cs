using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksStorage
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} {ex}";
                Clipboard.SetData(DataFormats.Text, $"{ex.Message} {ex}");
                MessageBox.Show($"{ex.Message} {ex}");
            }
        }
    }
}
