using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CardsAgainstHumanity.Installers;
using CardsAgainstHumanity.Interfaces;

namespace CardsAgainstHumanity.Models
{
    public class GetCard : IGetCard
    {
        public GetCard()
        {
        }

        public List<string> Request(string url)
        {

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            return responseFromServer.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }

    }
}