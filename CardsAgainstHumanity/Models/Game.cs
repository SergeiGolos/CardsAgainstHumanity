using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class Game : IGame    
    {        

        public Game(ICardResolver card)
        {      
            Player = new List<IPlayer>()
            {
                new RandoPlayer()
            };
            WhiteDeck = new Deck(card.GetWhite());
            BlackDeck = new Deck(card.GetBlack());
        }

        public IList<IPlayer> Player { get; set; }

        public int ScoreLimit { get; set; }        
        public IDeck WhiteDeck { get; set; }
        public IDeck BlackDeck { get; set; }       

        public IRound NewRound()
        {
            Round = new Round(BlackDeck.Draw(1).First());
            foreach (var player in Player)
            {
                player.RoundStart(this, Round);
            }

            return Round;
        }

        public IRound Round { get; set; }

        public bool EndRound()
        {
            var cards = Round.Score();
            var blackCard = Round.BlackCard;
            var player = Player.FirstOrDefault(n => n.Id == cards.Id);
            
            if (player == null)
            {
                return false;
            }
            
            player.Points.Add(new RoundResult()
            {
                BlackCard = blackCard.Id,
                WhiteCards = cards.Cards.Select(n=>n.Id).ToList()
            });

            Round = null;
            return true;
        }
    }
}