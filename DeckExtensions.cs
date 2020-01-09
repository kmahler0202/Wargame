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
    }
}
