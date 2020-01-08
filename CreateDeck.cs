using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public class CreateDeck

    {
        public List<Card> CreateDeckList = new List<Card>();
        public Dictionary<int, Card> IndexedDeck = new Dictionary<int, Card>();

        public CreateDeck()
        {
            int i = 0;
            foreach (Suit Color in Enum.GetValues(typeof(Suit)))
            {
                foreach (Number name in Enum.GetValues(typeof(Number)))
                {
                    Card nextCard = new Card(Color, name);
                    CreateDeckList.Add(nextCard);
                    IndexedDeck.Add(i++, nextCard);
                }
            }
        }
        

    }
}
