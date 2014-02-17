using System.Collections.Generic;
namespace CardsAgainstHumanity.Interfaces
{
    public interface IRound
    {
        ICard BlackCard { get; set; }
        IList<IPlayerCards> WhiteCards { get; set; }

        int RoundLimit { get; set; }
        int RoundStartDelay { get; set; }
        
        IPlayerCards Score();
        bool PlayCards(string id, IList<ICard> cards);
        bool SelectWinner(string id);
        
    }
}