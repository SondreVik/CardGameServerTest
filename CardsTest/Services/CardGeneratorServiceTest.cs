using CardsLibrary.Model;
using CardsLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CardsTest.Services
{
    
    public class CardGeneratorServiceTest
    {
        private ICardGeneratorService _service;
        private Mock<ICardShuffleService> _cardShuffleService;

        public CardGeneratorServiceTest()
        {
            _cardShuffleService = new Mock<ICardShuffleService>();
            _service = new CardGeneratorService(_cardShuffleService.Object);
        }

        [Fact]
        public void CardGeneratorService_GenerateStandardDeck_Has52Cards()
        {
            var cards = _service.GenerateStandardDeck();
            Assert.Equal(52, cards.Count);
        }

        [Fact]
        public void CardGeneratorService_GenerateStandardDeckWithIgnored_HasAllCardsExceptIgnored()
        {
            IList<Card> ignoreCards = new List<Card>
            {
                new Card
                {
                    Type = CardType.Diamonds,
                    Value = CardValue.Ace
                },
                new Card
                {
                    Type = CardType.Hearts,
                    Value = CardValue.Eight
                },
                new Card
                {
                    Type = CardType.Kloves,
                    Value = CardValue.Five
                },
                new Card
                {
                    Type = CardType.Spades,
                    Value = CardValue.Jack
                }
            };
            var cards = _service.GenerateStandardDeck(ignoreCards);
            Assert.Equal(52, cards.Count + ignoreCards.Count);
            foreach (var ignoreCard in ignoreCards)
                Assert.False(cards.Any(crd => crd.Type == ignoreCard.Type && crd.Value == ignoreCard.Value));
        }
    }
}
