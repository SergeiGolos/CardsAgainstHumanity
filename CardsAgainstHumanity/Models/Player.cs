using System.Collections;
using System.Collections.Generic;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<ICard> Points { get; set; }
    }
}