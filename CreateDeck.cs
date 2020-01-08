using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public class CreateDeck

    {
        public List<Card> CreateDeckList = new List<Card>();

        public CreateDeck()
        {
            foreach (Suit Color in Enum.GetValues(typeof(Suit)))
            {
                foreach (Number name in Enum.GetValues(typeof(Number)))
                {
                    Card nextCard = new Card(Color, name);
                    CreateDeckList.Add(nextCard);

                }
            }
        }
        

    }
}
