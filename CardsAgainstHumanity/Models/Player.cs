using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CardsAgainstHumanity.Interfaces;
using Castle.Core.Internal;

namespace CardsAgainstHumanity.Models
{
    public class Player : IPlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<ICard> Hand { get; set; }
        public IList<RoundResult> Points { get; set; }
        
        public void RoundStart(IGame game, IRound round)
        {
            var newCards = game.WhiteDeck.Draw((9  + round.BlackCard.Count) - Hand.Count);
            foreach (var newCard in newCards)
            {
                Hand.Add(newCard);
            }            
        }
    }
}