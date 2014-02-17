using System.Collections.Generic;
using CardsAgainstHumanity.Models;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IPlayer
    {
        string Id { get; set; }
        string Name { get; set; }
        IList<ICard> Hand { get; set; }
        IList<RoundResult> Points { get; set; }

        void RoundStart(IGame game, IRound round);
    }
}