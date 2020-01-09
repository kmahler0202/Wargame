using System;
using System.Text.Json;
using System.Linq;

namespace War
{
    public class Program
    {
        static void Main(string[] args)
        {
            PlayerDeck myDeck = PlayerDeck.CreateDefaultDeck();
            myDeck.Shuffle(20);
            var player1deck = new PlayerDeck(myDeck.Draw(26, true));
            var cpudeck = new PlayerDeck(myDeck.Draw(26, true));
            
            
            
            var player1card = player1deck.Draw(1, true).First();
            Console.WriteLine(player1card.ToJsonString());

            var cpucard = cpudeck.Draw(1, true).First();
            Console.WriteLine(cpucard.ToJsonString());

            if (player1card.ValueWar > cpucard.ValueWar)
            {
                Console.WriteLine("Player One Wins this battle!");
                player1deck.addtodiscard(player1card);
                player1deck.addtodiscard(cpucard);
            }

            else if (player1card.ValueWar < cpucard.ValueWar)
            {
                Console.WriteLine("The CPU Wins this battle!");
                cpudeck.addtodiscard(player1card);
                cpudeck.addtodiscard(cpucard);
            }

            else
                Console.WriteLine("There has been a tie! Draw another card.");

            Console.WriteLine("Press Spacebar to play the next round.");
            Console.ReadKey();

            
            
           
        }
    }
}
