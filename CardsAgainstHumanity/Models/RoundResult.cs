using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsAgainstHumanity.Models
{    
    public class RoundResult
    {
        public string BlackCard { get; set; }
        public IList<string> WhiteCards { get; set; }
    }
}
