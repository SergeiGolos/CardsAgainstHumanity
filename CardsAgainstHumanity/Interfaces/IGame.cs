using System.Collections.Generic;
using CardsAgainstHumanity.Models;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IGame
    {
        int ScoreLimit { get; set; }

        IDeck WhiteDeck { get; set; }
        IDeck BlackDeck { get; set; }
        IList<IPlayer> Player { get; set; }

        IRound NewRound();
        IRound Round { get; set; }
        bool EndRound();
    }
}