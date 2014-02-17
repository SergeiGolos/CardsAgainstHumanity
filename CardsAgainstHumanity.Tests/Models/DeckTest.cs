using System.Linq;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using FakeItEasy;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace CardsAgainstHumanity.Tests.Models
{
    public class DeckTest
    {
        [Fact]
        public void Deck_Create()
        {
            var enumerable = A.Fake<IList<ICard>>();
            var deck = new Deck(enumerable);
            Assert.NotNull(deck);
        }


        


        [Fact]
        public void Deck_Shuffle()
        {
            var enumerable = A.Fake<IList<ICard>>();
            var deck = new Deck(enumerable);
            Queue<int> shuffle = deck.Shuffle(10);

            Assert.NotNull(deck);
        }

        [Fact]
        public void Deck_Shuffle_Verify_Size()
        {
            var enumerable = A.Fake<IList<ICard>>();
            var deck = new Deck(enumerable);
            var size = 10;
            Queue<int> shuffle = deck.Shuffle(size);
            Assert.True(!shuffle.Contains(size));            
        }

        [Fact]
        public void Deck_Shuffle_Verify_AllValues()
        {
            var enumerable = A.Fake<IList<ICard>>();
            var deck = new Deck(enumerable);
            var size = 10;
            Queue<int> shuffle = deck.Shuffle(size);

            for (int i = 0; i <size; i++)
            {
                Assert.True(shuffle.Contains(i));
            }
        }

        [Fact]
        public void Deck_Shuffle_Verify_Random()
        {
            var enumerable = A.Fake<IList<ICard>>();
            var deck = new Deck(enumerable);
            var size = 10;
            List<int> shuffle = new List<int>(deck.Shuffle(size));

            var result = false;
            for (int i = 0; i < size; i++)
            {
                result = result || (shuffle.IndexOf(i) != i);
            }

            Assert.True(result);
        }


        [Theory,
        InlineData(1),
        InlineData(2),
        InlineData(10), 
        InlineData(13)]
        public void Deck_Draw_Count(int draw)
        {
            var cards = A.Fake<IList<ICard>>();
            A.CallTo(() => cards.Count).Returns(10);
            A.CallTo(() => cards[A<int>._]).ReturnsLazily(n =>
                new WhiteCard("1", string.Format("{0},1", n.Arguments[0].ToString())));

            var deck = new Deck(cards);
            IEnumerable<ICard> enumerable = deck.Draw(draw);

            Assert.Equal(draw, enumerable.Count());
            foreach (var card in enumerable)
            {
                Assert.NotNull(card);
                Assert.NotEmpty(card.Text);
            }
        }


        [Fact]
        public void Deck_Create_Size_1_CanDrawCardsAndReshuffle()
        {
            var cards = A.Fake<IList<ICard>>();
            A.CallTo(() => cards.Count).Returns(1);
            A.CallTo(() => cards[A<int>._]).ReturnsLazily(n =>
                new WhiteCard("1", string.Format("{0},1", n.Arguments[0].ToString())));

            var deck = new Deck(cards);
            IEnumerable<ICard> result = deck.Draw(10);
            foreach (var card in result)
            {
                Assert.Equal("0", card.Text);
            }
        }
    }
}