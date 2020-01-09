using System;
using System.Collections.Generic;

namespace War
{
    public class CardDeck
    {
        public List<Card> Cards { get; private set; }

        public CardDeck()
        {
            Cards = new List<Card>();
        }

        public CardDeck(List<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }

        public List<Card> Draw(int number = 1, bool remove = false)
        {
            if (number < 1 || number > Cards.Count)
                throw new ArgumentOutOfRangeException(nameof(number));

            Console.WriteLine($"Drawing {number} card(s).");

            var drawn = Cards.GetRange(0, number);

            if (remove)
                Cards.RemoveRange(0, number);

            return drawn;
        }

        public void Shuffle(int times = 1)
        {
            var rand = new Random();
            List<Card> workingCards = Cards;

            for (int shuff = 0; shuff < times; ++shuff)
            {
                Console.WriteLine("Shuffling...");
                List<Card> tempCards = new List<Card>();

                while (workingCards.Count > 0)
                {
                    int cardIndex = rand.Next(workingCards.Count);
                    tempCards.Add(workingCards[cardIndex]);
                    workingCards.RemoveAt(cardIndex);
                }

                workingCards = tempCards;
            }

            Cards = workingCards;

        }

        public static CardDeck CreateDefaultDeck()
        {
            var c = new CardDeck();

            foreach (Suit Color in Enum.GetValues(typeof(Suit)))
            {
                foreach (Number name in Enum.GetValues(typeof(Number)))
                {
                    c.Cards.Add(new Card(Color, name));
                }
            }

            return c;
        }

    }
}
