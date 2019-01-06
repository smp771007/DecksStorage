using DecksStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksStorage
{
    public static class DataHelper
    {
        internal static List<Deck> Decks { get; set; } = Convert(Properties.Settings.Default.Decks);

        /// <summary>
        /// 加入牌組
        /// </summary>
        /// <param name="deck"></param>
        internal static void AddDeck(Deck deck)
        {
            Decks.Add(deck);

            UpdateDeck();
        }

        /// <summary>
        /// 刪除牌組
        /// </summary>
        /// <param name="deck"></param>
        internal static void DeleteDeck(Deck deck)
        {
            Decks.Remove(deck);

            UpdateDeck();
        }

        /// <summary>
        /// 刪除所有牌組
        /// </summary>
        internal static void DeleteAllDeck()
        {
            Decks.Clear();

            UpdateDeck();
        }

        /// <summary>
        /// 更新牌組
        /// </summary>
        internal static void UpdateDeck()
        {
            Properties.Settings.Default.Decks = JsonConvert.SerializeObject(Decks);
            Properties.Settings.Default.Save();

            MainForm.Self.UpdateView();
        }

        /// <summary>
        /// 匯入
        /// </summary>
        /// <param name="decks"></param>
        internal static void Import(string decks)
        {
            //加入
            Decks.AddRange(Convert(decks));

            //更新
            UpdateDeck();
        }

        /// <summary>
        /// 牌組字串轉成物件
        /// </summary>
        /// <param name="deckString"></param>
        /// <returns></returns>
        private static List<Deck> Convert(string deckString)
        {
            return JsonConvert.DeserializeObject<List<Deck>>(deckString) ?? new List<Deck>();
        }
    }
}
