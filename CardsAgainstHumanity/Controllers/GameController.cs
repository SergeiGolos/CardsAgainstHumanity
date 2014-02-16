using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using System.Web.Http;

namespace CardsAgainstHumanity.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGame _game;

        public GameController(IGame game)
        {
            _game = game;
        }

        [HttpGet]
        public GameState GetState()
        {
            var blackCard = _game.BlackDeck.Draw(1).First();
            var whiteCards = _game.WhiteDeck.Draw(((BlackCard)blackCard).Count);

            return new GameState(blackCard, whiteCards);
        }

        [HttpGet]
        public List<ICard> WhiteCards(int count)
        {
            return _game.WhiteDeck.Draw(count).ToList();
        }
    }
}
