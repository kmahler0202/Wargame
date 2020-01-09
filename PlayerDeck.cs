using System;
using System.Collections.Generic;

namespace War
{
    public class PlayerDeck
    {
        public List<Card> Cards { get; private set; }
        public List<Card> Discard { get; private set; }

        public bool HasLost => Cards.Count + Discard.Count == 0;

        public PlayerDeck()
        {
            Cards = new List<Card>();
            Discard = new List<Card>();
        }

        public PlayerDeck(List<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
            Discard = new List<Card>();
        }

        public List<Card> Draw(int number = 1, bool remove = false)
        {

            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number));

            Console.WriteLine($"Drawing {number} card(s).");

            if(Cards.Count == 0)
            {
                if(Discard.Count == 0)
                {
                    throw new Exception("Cannot draw. Game over.");
                }

                Console.WriteLine($"{Discard.Count} card(s) in discard pile.");
                Cards = Discard.Shuffle(7);
                Discard.Clear();
            }

            var drawn = Cards.GetRange(0, number);

            if (remove)
                Cards.RemoveRange(0, number);

            return drawn;
        }

        public Card PlayCard()
        {
            return Draw(1, true)[0];
        }

        public void Shuffle(int times = 1)
        {
            Cards = Cards.Shuffle(times);
        }

        public void AddToDiscard(params Card[] cardsToDiscard)
        {
            Discard.AddRange(cardsToDiscard);
        }

        public static PlayerDeck CreateDefaultDeck()
        {
            var c = new PlayerDeck();

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
