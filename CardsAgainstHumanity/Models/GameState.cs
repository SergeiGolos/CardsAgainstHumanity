using System.Collections.Generic;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class GameState
    {
        private readonly ICard _black;
        private readonly IList<ICard> _white;

        public ICard Black
        {
            get { return _black; }
        }

        public IList<ICard> White
        {
            get { return _white; }
        }

        public GameState(ICard black, IList<ICard> white)
        {
            _black = black;
            _white = white;
        }
    }
}