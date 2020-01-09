using System;
using System.Text.Json;
using System.Linq;

namespace War
{
    public class Program
    {
        static void Main(string[] args)
        {
            PlayerDeck masterDeck = PlayerDeck.CreateDefaultDeck();
            masterDeck.Shuffle(20);

            var humanDeck = new PlayerDeck(masterDeck.Draw(26, true));
            var cpuDeck = new PlayerDeck(masterDeck.Draw(26, true));

            int battlecount = 0;

            while (!humanDeck.HasLost && !cpuDeck.HasLost)
            {
                ++battlecount;
                var playerCard = humanDeck.PlayCard();
                Console.WriteLine(playerCard.ToJsonString());

                var cpucard = cpuDeck.PlayCard();
                Console.WriteLine(cpucard.ToJsonString());

                if (playerCard.ValueWar > cpucard.ValueWar)
                {
                    Console.WriteLine("Human Wins this battle!");
                    humanDeck.AddToDiscard(playerCard, cpucard);
                }

                else if (playerCard.ValueWar < cpucard.ValueWar)
                {
                    Console.WriteLine("The CPU Wins this battle!");
                    cpuDeck.AddToDiscard(playerCard, cpucard);
                }

                else
                {
                    Console.WriteLine("There has been a tie! Draw three cards.");

                    for (int i = 0; i < 3; ++i)
                    {

                    }
                }

                //System.Threading.Thread.Sleep(1000);
                   
            }

            Console.WriteLine($"There have been {battlecount} battle(s).");

            if (humanDeck.HasLost)
            {
                Console.WriteLine("No suprise here. You have proven humans are obsolete. Time to die.");
            }

            if (cpuDeck.HasLost)
            {
                Console.WriteLine("Congratulations. You are the superior being.");
            }

            Console.ReadLine();

        }
    }
}
