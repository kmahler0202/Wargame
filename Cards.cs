using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace War
{
    public class Card
    { 
        [JsonConverter(typeof (JsonStringEnumConverter) )]
        public Suit Suit { get; }

        public string Color => Suit == Suit.Clubs || Suit == Suit.Spades ? "Black" : "Red";
        

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Number Number { get; }

        public int ValueWar => (int)Number;

        public static bool Count { get; internal set; }

        public Card(Suit Suit, Number Number)
        {
            this.Suit = Suit;
            this.Number = Number;

          }  
        
    }
}
