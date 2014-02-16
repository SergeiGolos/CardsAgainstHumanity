using System;
using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using Xunit;
using Xunit.Extensions;

namespace CardsAgainstHumanity.Tests.Models
{
    public class CardTest
    {
        [Fact]
        public void Card_White_Card()
        {
            string cardValue = "test";
            string formatCardWrapper = string.Format("{0},1", cardValue);
            ICard card = new WhiteCard(formatCardWrapper);
            Assert.Equal(cardValue, card.Text);
        }
        
        [Fact]
        public void Card_White_Card_Invalid()
        {
            string cardValue = "test";
            string formatCardWrapper = string.Format("{0}", cardValue);

            string message = Assert.Throws<ArgumentException>(() => new WhiteCard(formatCardWrapper)).Message;
            Assert.True(message.Contains(string.Format("[ test ]")));
        }

        [Theory,
         InlineData("text"),
         InlineData("\" testing , \""),
         InlineData("\" te,sting , \""),
        ]
        public void Card_White_Card_fromString(string cardValue)
        {            
            string formatCardWrapper = string.Format("{0},1", cardValue);
            ICard card = new WhiteCard(formatCardWrapper);
            Assert.Equal(cardValue, card.Text);
        }


        [Fact]
        public void Black_Card_Card()
        {
            string cardValue = "test";
            string formatCardWrapper = string.Format("{0},1,1", cardValue);
            ICard card = new BlackCard(formatCardWrapper);
            Assert.Equal(cardValue, card.Text);
        }

        [Fact]
        public void Black_Card_Card_Invalid_Arg_Count()
        {
            string cardValue = "test";
            string formatCardWrapper = string.Format("{0},1", cardValue);

            string message = Assert.Throws<ArgumentException>(() => new BlackCard(formatCardWrapper)).Message;
            Assert.True(message.Contains(string.Format("[ test,1 ]")));
        }

        [Fact]
        public void Black_Card_Card_Invalid_Arg_NonNumeric()
        {
            string cardValue = "test";
            string formatCardWrapper = string.Format("{0},,z", cardValue);

            string message = Assert.Throws<ArgumentException>(() => new BlackCard(formatCardWrapper)).Message;
            Assert.True(message.Contains(string.Format("[ test,,z ]")));
        }

        [Theory,
         InlineData("text"),
         InlineData("\" testing , \""),
         InlineData("\" te,sting , \""),
        ]
        public void Black_Card_Card_fromString(string cardValue)
        {
            string formatCardWrapper = string.Format("{0},1,1", cardValue);
            ICard card = new BlackCard(formatCardWrapper);
            Assert.Equal(cardValue, card.Text);
        }
    }
}