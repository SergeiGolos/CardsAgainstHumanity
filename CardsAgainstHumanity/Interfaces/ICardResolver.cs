using System.Collections.Generic;

namespace CardsAgainstHumanity.Interfaces
{
    public interface ICardResolver
    {
        IList<Interfaces.ICard> GetWhite();

        IList<Interfaces.ICard> GetBlack();

    }
}
