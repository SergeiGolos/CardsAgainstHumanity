using System.Collections.Generic;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class RandoPlayer : IPlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<ICard> Hand { get; set; }
        public IList<RoundResult> Points { get; set; }

        public void RoundStart(IGame game, IRound round)
        {

            round.PlayCards(Id, game.WhiteDeck.Draw(round.BlackCard.Count));
        }
    }
}