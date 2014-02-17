using System.Linq;
using CardsAgainstHumanity.Installers;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class CardResolver : ICardResolver
    {
        private readonly IGetCard _resolver;

        public CardResolver(IGetCard resolver)
        {
            _resolver = resolver;
        }

        public System.Collections.Generic.IList<ICard> GetWhite()
        {
            var list = _resolver.Request("http://www.cardsagainsthumanity.com/lab/LoadWhiteCards.php");
            return list.Skip(1).Select(n => new WhiteCard(list.IndexOf(n).ToString(), n)).ToList<ICard>();
        }

        public System.Collections.Generic.IList<ICard> GetBlack()
        {
            var list = _resolver.Request("http://www.cardsagainsthumanity.com/lab/LoadBlackCards.php");
            return list.Skip(1).Select(n => new BlackCard(list.IndexOf(n).ToString(), n)).ToList<ICard>();
        }        
       
        
    }
}
