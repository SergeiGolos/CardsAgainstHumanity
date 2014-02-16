using System;
using System.Linq;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public abstract class Card : ICard
    {
        protected Card(string value, int size)
        {
            string[] split = value.Split(',');
            if (split.Length < size)
            {
                throw new ArgumentException(string.Format("Invalid card format: Requires more arguments. [ {0} ]", value));
            }

            this.Text = string.Join(",", split.Take(split.Length - (size - 1)));
        }

        public string Text { get; set; }        
    }

    public class WhiteCard : Card
    {
        public WhiteCard(string value) : base(value,2)
        {           
        }
    }

    public class BlackCard : Card
    {
        public BlackCard(string value) : base(value,3)
        {            
            var countString = value.Substring(value.LastIndexOf(",", System.StringComparison.Ordinal) + 1);
            var count = 0;
            if (!int.TryParse(countString, out count))
            {
                throw  new ArgumentException(string.Format("Invalid card format: Requires numeric argument. [ {0} ]", value));
            }
            this.Count = count;
            
        }

        public int Count { get; set; }
    }
}