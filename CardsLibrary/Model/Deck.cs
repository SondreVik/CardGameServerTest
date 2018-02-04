using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Deck: Entity
    {
        public List<Card> Cards { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HiddenCards { get; set; }
        public string TableID { get; set; }
        public string PlayerID { get; set; }
    }
}
