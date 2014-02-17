using System.Collections.Generic;

namespace CardsAgainstHumanity.Interfaces
{
    public interface IGetCard
    {
        List<string> Request(string url);
    }
}