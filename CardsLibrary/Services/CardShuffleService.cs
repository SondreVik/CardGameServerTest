using CardsLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsLibrary.Services
{
    public interface ICardShuffleService
    {
        IList<Card> ShuffleCards(IList<Card> cards = null);
    }
    public class CardShuffleService : ICardShuffleService
    {
        public IList<Card> ShuffleCards(IList<Card> cards = null)
        {
            if (cards == null) return new List<Card>();
            var rnd = new Random();
            var cardSorting = new List<CardToSort>();
            foreach (var card in cards)
                cardSorting.Add(new CardToSort
                {
                    Order = rnd.Next(),
                    Card = card
                });

            return cardSorting
                .OrderBy(crd => crd.Order)
                .Select(crd => crd.Card)
                .ToList();
        }

        private struct CardToSort
        {
            public int Order { get; set; }
            public Card Card { get; set; }
        }
    }
}
