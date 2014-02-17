using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using CardsAgainstHumanity.Controllers;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using FakeItEasy;
using Xunit;
using System.Collections.Generic;

namespace CardsAgainstHumanity.Tests.Controllers
{    
    public class GameControllerTest
    {
        [Fact]  
        public void GameController_Get_NewState()
        {
            var game = A.Fake<IGame>();
            var round = A.Fake<IRound>();
            A.CallTo(() => round.BlackCard).Returns(new BlackCard("1", "test,1,1"));
            A.CallTo(() => game.NewRound()).Returns(round);
            
            var controller = new GameController(game);
            var result = controller.GetState();            
            Assert.Equal("test", result.BlackCard.Text);
        }

        [Fact]
        public void GameController_Get_WhiteCard()
        {
            var game = A.Fake<IGame>();
            var deck = A.Fake<IDeck>();
            A.CallTo(() => game.WhiteDeck).Returns(deck);
            A.CallTo(() => deck.Draw(A<int>._)).Returns(new List<ICard>() { new WhiteCard("1", "test,1") });

            var controller = new GameController(game);
            var result = controller.WhiteCards(1);            
            Assert.Equal("test", result.First().Text);
        }
    }
}
