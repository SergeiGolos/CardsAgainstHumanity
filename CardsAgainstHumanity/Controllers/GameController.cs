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
            return _game.NewState();
        }

        [HttpGet]
        public List<ICard> WhiteCards(int count)
        {
            return _game.WhiteDeck.Draw(count).ToList();
        }
    }
}
