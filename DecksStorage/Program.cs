using System;
using System.Collections.Generic;
using System.IO;
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
            catch (Exception e)
            {
                File.WriteAllText(UserData.ERR_LOG, $"{Settings.Version}\r\n[{DateTime.Now:yyyyMMdd:HH:mm:ss}]\r\n{e}");
                MessageBox.Show($"程式錯誤，請提供{UserData.ERR_LOG}給作者除錯。");
            }
        }
    }
}
