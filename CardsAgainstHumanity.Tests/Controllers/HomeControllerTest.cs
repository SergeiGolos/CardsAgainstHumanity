using System;
using System.Collections;
using System.Web.Mvc;
using CardsAgainstHumanity.Controllers;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using FakeItEasy;
using Xunit;
using System.Collections.Generic;

namespace CardsAgainstHumanity.Tests.Controllers
{    
    public class HomeControllerTest
    {
        [Fact]  
        public void HomeController_GetIndex()
        {
            var game = A.Fake<IGame>();
            var round = A.Fake<IRound>();
            A.CallTo(() => round.BlackCard).Returns(new BlackCard("1", "test,1,1"));
            A.CallTo(() => game.NewRound()).Returns(round);
                
            var controller = new HomeController(game);
            var result = (ViewResult)controller.Index();            
            Assert.Equal("test",((IRound)result.Model).BlackCard.Text);
        }
    }
}
