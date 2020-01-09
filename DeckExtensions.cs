using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace War
{
    public static class DeckExtensions
    {
        public static string ToJsonString(this List<Card> cards)
        {
            return JsonSerializer.Serialize(cards, new JsonSerializerOptions() { WriteIndented = true });
        }
        public static string ToJsonString(this Card card)
        {
            return JsonSerializer.Serialize(card, new JsonSerializerOptions() { WriteIndented = true });
        }

        public static List<Card> Shuffle(this List<Card> deck, int times = 1)
        {
            var rand = new Random();
            List<Card> workingCards = deck;

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

            return workingCards;
        }
    }
}
