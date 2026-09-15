using System;

namespace uno_csharp_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa kortleken
            CardDecks deck = new CardDecks();

            Console.WriteLine($"Kortleken är klar med {deck.Count} kort!\n");

            // Dra och skriv ut de första 5 korten för att testa färger och typer
            Console.WriteLine("Drar 5 slumpmässiga kort:");
            for (int i = 0; i < 5; i++)
            {
                Card drawnCard = deck.Draw();
                drawnCard.PrintCard();
            }

            Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}