using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;

namespace CardsAgainstHumanity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGame _game;

        public HomeController(IGame game)
        {
            _game = game;
        }

        public ActionResult Index()
        {
            var blackCard = _game.BlackDeck.Draw(1).First();
            var whiteCards = _game.WhiteDeck.Draw(((BlackCard) blackCard).Count);            

            return View(new GameState(blackCard, whiteCards));
        }
    }
}
