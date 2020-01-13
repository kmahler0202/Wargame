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
                var playercard = humanDeck.PlayCard();
                Console.WriteLine(playercard.ToJsonString());

                var cpucard = cpuDeck.PlayCard();
                Console.WriteLine(cpucard.ToJsonString());



                if (playercard.ValueWar > cpucard.ValueWar) 
                {
                    Console.WriteLine("Human Wins this battle!");
                    humanDeck.AddToDiscard(playercard, cpucard);
                }

                else if (playercard.ValueWar < cpucard.ValueWar)
                {
                    Console.WriteLine("The CPU Wins this battle!");
                    cpuDeck.AddToDiscard(playercard, cpucard);
                }
                else if (playercard.ValueWar == cpucard.ValueWar)

                  
                {                                 
                                        

                    {

                        Console.WriteLine("There has been a tie! Draw three cards.");
                        var playertie1 = humanDeck.PlayCard();
                        var cputie1 = cpuDeck.PlayCard();

                        var playertie2 = humanDeck.PlayCard();
                        var cputie2 = cpuDeck.PlayCard();

                        var playertie3 = humanDeck.PlayCard();
                        var cputie3 = cpuDeck.PlayCard();

                        var playerCardtie = humanDeck.PlayCard();
                        var cpucardtie = cpuDeck.PlayCard();
                        

                        
                        Console.WriteLine("Human's three Cards:");
                        
                        Console.WriteLine(playertie1.ToJsonString());
                        Console.WriteLine(playertie1.ToJsonString());
                        Console.WriteLine(playertie2.ToJsonString());
                        Console.WriteLine(playertie3.ToJsonString());

                        Console.WriteLine("CPU's three Cards:");
                        Console.WriteLine(cputie1.ToJsonString());
                        Console.WriteLine(cputie1.ToJsonString());
                        Console.WriteLine(cputie2.ToJsonString());
                        Console.WriteLine(cputie3.ToJsonString());

                        if (playerCardtie.ValueWar == cpucardtie.ValueWar)
                        {

                            var Wartiecpu = cpuDeck.PlayCard();
                            var Wartieplayer = cpuDeck.PlayCard();

                            Console.WriteLine("Human's War Card:");
                            Console.WriteLine(Wartieplayer.ToJsonString());
                            Console.WriteLine("CPU's War Card:");
                            Console.WriteLine(Wartiecpu.ToJsonString());
                        

                           if (Wartiecpu.ValueWar > Wartieplayer.ValueWar)

                            {
                                Console.WriteLine("CPU Wins This Debaccle");
                                cpuDeck.AddToDiscard(playercard, cpucard, cpucardtie, playerCardtie, playertie2, cputie2, playertie3, cputie3, Wartieplayer, Wartiecpu);
                            }
                            else if (Wartiecpu.ValueWar > Wartieplayer.ValueWar)
                            {
                                Console.WriteLine("Human Wins This Debaccle");
                                humanDeck.AddToDiscard(playercard, cpucard, cpucardtie, playerCardtie, playertie2, cputie2, playertie3, cputie3, Wartieplayer, Wartiecpu);
                            }
                        }

                        else if (cpucardtie.ValueWar > playerCardtie.ValueWar)
                        {
                            Console.WriteLine("Human's War Card:");
                            Console.WriteLine(playerCardtie.ToJsonString());
                            Console.WriteLine("CPU's War Card:");
                            Console.WriteLine(cpucardtie.ToJsonString());

                            Console.WriteLine("The CPU win's all 10 cards in this War...");
                            cpuDeck.AddToDiscard(playercard, cpucard, cpucardtie, playerCardtie, playertie1, cputie1, playertie2, cputie2, playertie3, cputie3);
                        }
                        else if (cpucardtie.ValueWar < playerCardtie.ValueWar)
                        {
                            Console.WriteLine("Human's War Card:");
                            Console.WriteLine(playerCardtie.ToJsonString());
                            Console.WriteLine("CPU's War Card:");
                            Console.WriteLine(cpucardtie.ToJsonString());

                            Console.WriteLine("Congratulations! You win all 10 Cards this War");
                            humanDeck.AddToDiscard(playercard, cpucard, cpucardtie, playerCardtie, playertie1, cputie1, playertie2, cputie2, playertie3, cputie3);
                        }

                    }
                    


                }

                //System.Threading.Thread.Sleep(3000);
                   
            }

            Console.WriteLine($"There have been {battlecount} battle(s).");
            Console.WriteLine(humanDeck.Discard.Count);
            Console.WriteLine(cpuDeck.Discard.Count);
            Console.WriteLine(humanDeck.Cards.Count);
            Console.WriteLine(cpuDeck.Cards.Count);

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
