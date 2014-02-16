using System.Collections.Generic;
using CardsAgainstHumanity.Models;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IGame
    {
        IDeck WhiteDeck { get; set; }
        IDeck BlackDeck { get; set; }
        IList<Player> Player { get; set; }

        GameState NewState();
    }
}