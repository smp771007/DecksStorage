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
        internal static List<Deck> Decks { get; set; } = UserData.Data.Decks;

        /// <summary>
        /// 加入牌組
        /// </summary>
        /// <param name="deck"></param>
        internal static void AddDeck(Deck deck)
        {
            Decks.Add(deck);

            UpdateDeck(MainForm.ReflashType.Bottom, true);
        }

        /// <summary>
        /// 刪除牌組
        /// </summary>
        /// <param name="deck"></param>
        internal static void DeleteDeck(Deck deck)
        {
            Decks.Remove(deck);

            UpdateDeck(MainForm.ReflashType.Keep);
        }

        /// <summary>
        /// 刪除所有牌組
        /// </summary>
        internal static void DeleteAllDeck()
        {
            Decks.Clear();

            UpdateDeck(MainForm.ReflashType.Top);
        }

        /// <summary>
        /// 更新牌組
        /// </summary>
        /// <param name="reflashType">刷新類型</param>
        /// <param name="clearSort">清除排序</param>
        internal static void UpdateDeck(MainForm.ReflashType reflashType, bool clearSort = false)
        {
            UserData.Data.Decks = Decks;
            UserData.Save();

            MainForm.Self.UpdateView(reflashType, clearSort);
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
            UpdateDeck(MainForm.ReflashType.Bottom, true);
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
