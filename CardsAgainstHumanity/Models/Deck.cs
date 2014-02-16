using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class Deck : IDeck
    {
        private readonly IList<ICard> _cards;
        private Queue<int> deck;

        public Deck(IList<ICard> cards)
        {
            _cards = cards;
            var size = _cards.Count;
            deck = Shuffle(size);
        }

        public IList<ICard> Draw(int count)
        {
            var result = new List<ICard>();
            while (count > 0)
            {                
                if (deck.Count() == 0)
                {
                    deck = Shuffle(_cards.Count);
                }
                result.Add(_cards[deck.Dequeue()]);
                count--;
            }

            return result;
        }

        public Queue<int> Shuffle(int size)
        {          
            Random rng = new Random();
            List<int> list = Enumerable.Range(0, size).ToList();
            for (int i = 0; i < size; i++)
            {             
                int k = rng.Next(size-1);
                int value = list[k];
                list[k] = list[i];
                list[i] = value;            
            }
            return new Queue<int>(list);
        }
    }
}