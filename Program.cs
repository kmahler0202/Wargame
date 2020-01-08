using System;
using System.Text.Json;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDeck myDeck = new CreateDeck();
            Console.WriteLine(JsonSerializer.Serialize(myDeck.CreateDeckList, new JsonSerializerOptions() { WriteIndented = true }));
            Console.WriteLine(myDeck.CreateDeckList.Count);

        }
    }
}
