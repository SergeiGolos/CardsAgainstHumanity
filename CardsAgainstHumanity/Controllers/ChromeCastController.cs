using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Controllers
{
    public class ChromeCastController : Controller
    {
        private readonly IGame _game;

        public ChromeCastController(IGame game)
        {           
            _game = game;
        }

        //
        // GET: /ChromeCast/
        public ActionResult Index()
        {
            var round = _game.NewRound();            
            return View(round);
        }
	}
}