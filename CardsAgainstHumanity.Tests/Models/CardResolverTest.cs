using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using FakeItEasy;
using Xunit;
using CardsAgainstHumanity.Installers;

namespace CardsAgainstHumanity.Tests.Models
{
    public class CardResolverTest
    {
        [Fact]
        public void CardResolver_Created()
        {
            var getCard = A.Fake<IGetCard>();
            var resolver = new CardResolver(getCard);
            Assert.NotNull(resolver);
        }

        [Fact]
        public void CardResolver_Resquest_White()
        {
            var getCard = A.Fake<IGetCard>();

            A.CallTo(() => getCard.Request(A<string>._)).Returns(new List<string>() {",1", ",1"});
            var resolver = new CardResolver(getCard);
            var deck = resolver.GetWhite();
            Assert.NotNull(deck);

            Assert.Equal(1, deck.Count);
        }

        [Fact]
        public void CardResolver_Resquest_Black()
        {
            var getCard = A.Fake<IGetCard>();

            A.CallTo(() => getCard.Request(A<string>._)).Returns(new List<string>() { ",,1", ",,1" });
            var resolver = new CardResolver(getCard);
            var deck = resolver.GetBlack();
            Assert.NotNull(deck);

            Assert.Equal(1, deck.Count);
        }

        [Fact]
        public void CardResolver_Resquest_Black_ValidIndex_Id()
        {
            var getCard = A.Fake<IGetCard>();

            A.CallTo(() => getCard.Request(A<string>._)).Returns(new List<string>() {"", "q,,1", "w,,1" });
            var resolver = new CardResolver(getCard);
            var deck = resolver.GetBlack();                        
            Assert.Equal("1", deck.First().Id);
            Assert.Equal("2", deck.Last().Id);
        }
    }
}
