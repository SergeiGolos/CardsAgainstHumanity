using System.Collections;
using System.Collections.Generic;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class Game : IGame    
    {
        public Game(ICardResolver card)
        {
            WhiteDeck = new Deck(card.GetWhite());
            BlackDeck = new Deck(card.GetBlack());
        }

        public IDeck WhiteDeck { get; set; }
        public IDeck BlackDeck { get; set; }

        public IList<Player> Player { get; set; }        
    }
}