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
        internal static List<Deck> Decks { get; set; } = JsonConvert.DeserializeObject<List<Deck>>(Properties.Settings.Default.Decks) ?? new List<Deck>();

        internal static void AddDeck(Deck deck)
        {
            Decks.Add(deck);

            UpdateDeck();
        }

        internal static void DeleteDeck(Deck deck)
        {
            Decks.Remove(deck);

            UpdateDeck();
        }

        internal static void DeleteAllDeck()
        {
            Decks.Clear();

            UpdateDeck();
        }

        private static void UpdateDeck()
        {
            Properties.Settings.Default.Decks = JsonConvert.SerializeObject(Decks);
            Properties.Settings.Default.Save();

            MainForm.Self.UpdateView();
        }
    }
}
