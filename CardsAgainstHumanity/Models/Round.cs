using CardsAgainstHumanity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Internal;

namespace CardsAgainstHumanity.Models
{
    public class Round : IRound
    {
        public Round(ICard black)
        {
            BlackCard = black;
            WhiteCards = new List<IPlayerCards>();
        }

        public ICard BlackCard { get; set; }
        public IList<IPlayerCards> WhiteCards { get; set; }
        public int RoundLimit { get; set; }
        public int RoundStartDelay { get; set; }

        public bool PlayCards(string id, IList<ICard> cards)
        {
            if (WhiteCards.Count(n => n.Id == id) == 0)
            {
                WhiteCards.Add(new PlayerCards() { Cards = cards, Id = id });
                return true;
            }
            return false;
        }

        public bool SelectWinner(string id)
        {
            var player = WhiteCards.FirstOrDefault(n => n.Id == id);
            WhiteCards.ForEach(n => { n.Winner = false; });
            return player != null && (player.Winner = true);
        }

        public IPlayerCards Score()
        {
            var winningCards = WhiteCards.FirstOrDefault(n => n.Winner);
            
            WhiteCards = null;
            BlackCard = null;

            return winningCards;
        }
    }
}
