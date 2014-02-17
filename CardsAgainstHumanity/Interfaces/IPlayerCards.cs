using System.Collections.Generic;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IPlayerCards
    {
        string Id { get; set; }
        IEnumerable<ICard> Cards { get; set; }
        bool Winner { get; set; }
    }

    class PlayerCards : IPlayerCards
    {
        public string Id { get; set; }
        public IEnumerable<ICard> Cards { get; set; }
        public bool Winner { get; set; }
    }
}