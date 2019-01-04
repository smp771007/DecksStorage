using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksStorage.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Class { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
    }
}
