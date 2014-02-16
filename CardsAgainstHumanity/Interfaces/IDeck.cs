using System.Collections.Generic;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IDeck
    {
        IList<ICard> Draw(int count);
        Queue<int> Shuffle(int size);
    }
}