using CardsLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsLibrary.Services
{
    public interface ICardGeneratorService
    {
        IList<Card> GenerateStandardDeck(IList<Card> ignoreCards = null);
        IList<Card> GenerateStandardShuffledDeck(IList<Card> ignoreCards = null);
    }
    public class CardGeneratorService : ICardGeneratorService
    {
        public ICardShuffleService _cardShuffleService;

        public CardGeneratorService(ICardShuffleService cardShuffleService)
        {
            _cardShuffleService = cardShuffleService;
        }
        public IList<Card> GenerateStandardDeck(IList<Card> ignoreCards = null)
        {
            IList<Card> ret = new List<Card>();
            ignoreCards = ignoreCards ?? new List<Card>();
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                foreach(CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    if (!ignoreCards.Any(crd => crd.Type == type && crd.Value == value))
                        ret.Add(new Card
                        {
                            Type = type,
                            Value = value
                        });
                }
            }
            return ret;
        }

        public IList<Card> GenerateStandardShuffledDeck(IList<Card> ignoreCards = null)
        {
            return _cardShuffleService.ShuffleCards(GenerateStandardDeck(ignoreCards));
        }
    }
}
