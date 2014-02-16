using System.Collections.Generic;

namespace CardsAgainstHumanity.Installers
{
    public interface IGetCard
    {
        List<string> Request(string url);
    }
}