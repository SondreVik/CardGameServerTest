using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Table : Entity
    {
        public List<Deck> Decks { get; set; }
        public List<Player> Players { get; set; }
    }
}
