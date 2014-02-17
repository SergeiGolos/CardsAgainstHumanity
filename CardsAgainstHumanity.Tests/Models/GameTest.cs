using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using FakeItEasy;
using Xunit;

namespace CardsAgainstHumanity.Tests.Models
{
    public class GameTest
    {
        [Fact]
        public void Game_Created()
        {
            var cardResolver = A.Fake<ICardResolver>();
            var game = new Game(cardResolver);
            Assert.NotNull(game);
        }

        [Fact]
        public void Game_GameState()
        {
            var cardResolver = A.Fake<ICardResolver>();

            A.CallTo(()=>cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(()=>cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",",1") });
                        

            var game = new Game(cardResolver);            
            var round = game.NewRound();            

            Assert.NotNull(round);

            
            Assert.Equal(string.Empty, round.BlackCard.Text);
            Assert.Equal(1, round.BlackCard.Count);
            
        }


        [Fact]
        public void Game_GameState_Player_AddsCards()
        {
            var cardResolver = A.Fake<ICardResolver>();

            A.CallTo(()=>cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(()=>cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();            
            Assert.NotNull(round);
            
            Assert.True(round.PlayCards("", game.WhiteDeck.Draw(1)));
            Assert.Equal(string.Empty, round.BlackCard.Text);
            Assert.Equal(1, round.BlackCard.Count);

            Assert.Equal(string.Empty, round.WhiteCards.First().Cards.First().Text);
        }


        [Fact]
        public void Game_GameState_Player_AddsCards_Twice()
        {
            var cardResolver = A.Fake<ICardResolver>();

            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();
            Assert.NotNull(round);


            Assert.True(round.PlayCards("1", game.WhiteDeck.Draw(1)));
            Assert.False(round.PlayCards("1", game.WhiteDeck.Draw(1)));
            
        }


        [Fact]
        public void Game_GameState_Player_Select_Winner()
        {
            var cardResolver = A.Fake<ICardResolver>();

            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();
            Assert.NotNull(round);

            
            round.PlayCards("1", game.WhiteDeck.Draw(1));
            Assert.True(round.SelectWinner("1"));
        }


        [Fact]
        public void Game_GameState_Player_Select_WinnerFail()
        {
            var cardResolver = A.Fake<ICardResolver>();

            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();
            Assert.NotNull(round);

            
            round.PlayCards("1", game.WhiteDeck.Draw(1));
            Assert.False(round.SelectWinner("2"));
        }


        [Fact]
        public void Game_GameState_Get_Winner()
        {
            var cardResolver = A.Fake<ICardResolver>();
            var cardValue = "test";
            string id = "1";

            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",cardValue + ",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();
            Assert.NotNull(round);



            round.PlayCards(id, game.WhiteDeck.Draw(1));
            round.SelectWinner(id);
            var result = round.Score();
            Assert.NotNull(result);

            Assert.Equal(id, result.Id);
            Assert.Equal(cardValue, result.Cards.First().Text);
        }

        [Fact]
        public void Game_GameState_PullRound()
        {
            var cardResolver = A.Fake<ICardResolver>();
            var cardValue = "test";
            string id = "1";

            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",cardValue + ",1") });

            var game = new Game(cardResolver);
            var round = game.NewRound();
            
            Assert.Equal(round, game.Round);
        }


        [Fact]
        public void Game_Player_NotNull()
        {
            string cardValue = "test";
            var cardResolver = A.Fake<ICardResolver>();            
            A.CallTo(() => cardResolver.GetBlack()).Returns(new List<ICard>() { new BlackCard("1", ",,1") });            
            A.CallTo(() => cardResolver.GetWhite()).Returns(new List<ICard>() { new WhiteCard("1",cardValue + ",1") });

            var game = new Game(cardResolver);
            Assert.NotNull(game.Player);
        }
    }
}