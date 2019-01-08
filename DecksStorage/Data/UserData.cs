using DecksStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksStorage
{
    public static class UserData
    {
        public const string FILE_PATH = "user_data.config";
        public const string ERR_LOG = "err.log";
        public static Data Data { get; set; }

        static UserData()
        {
            try
            {
                if (File.Exists(FILE_PATH))
                {
                    var file = File.ReadAllText(FILE_PATH, Encoding.UTF8);

                    Data = JsonConvert.DeserializeObject<Data>(file);

                    return;
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(ERR_LOG, $@"[{DateTime.Now:yyyyMMdd:HH:mm:ss}]{e.Message}\r\n{e}\r\n");
            }

            Data = new Data();
        }

        internal static void Save()
        {
            File.WriteAllText(FILE_PATH, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
    }

    public class Data
    {
        public List<Deck> Decks { get; set; } = new List<Deck>();
        public FormWindowState MFState { get; set; } = FormWindowState.Normal;
        public Point MFLocation { get; set; } = new Point { X = 0, Y = 0 };
        public Size MFSize { get; set; } = new Size { Width = 0, Height = 0 };
    }
}
