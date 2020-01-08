using System;
using System.Text.Json;
using System.Linq;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck myDeck = CardDeck.CreateDefaultDeck();
            myDeck.Shuffle(20);
            var player1deck = new CardDeck(myDeck.Draw(26, true));
            var player2deck = new CardDeck(myDeck.Draw(26, true));
            Console.WriteLine(player1deck.Draw(5).ToJsonString());
            Console.ReadLine();
        }
    }
}
