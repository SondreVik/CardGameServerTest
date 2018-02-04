using CardsLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary.Model
{
    public class Card : Entity
    {
        public CardType Type { get; set; }
        public CardValue Value { get; set; }
        public bool Visible { get; set; }
        public int? CardIndex { get; set; }
        public string DeckID { get; set; }
    }

    public enum CardType
    {
        Spades = 0,
        Kloves = 1,
        Hearts = 2,
        Diamonds = 3
    }

    public enum CardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}
