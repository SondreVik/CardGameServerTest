using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Player : Entity
    {
        public List<Deck> Decks { get; set; }
        public User User { get; set; }
        public string TableID { get; set; }
    }
}
