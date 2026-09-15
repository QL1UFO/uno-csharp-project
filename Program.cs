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
        }
        public static void Main()
        {

            Console.WriteLine("Välkomen till UNO!");
            int numberOfPlayers = GetNumberOfPlayers();

            Console.WriteLine($"Spelet startar med {numberOfPlayers} spelare!");

            var players = new List<Player>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.WriteLine($"Ange namn för spelare {i}:");
                string? name = Console.ReadLine();
                players.Add(new Player(string.IsNullOrWhiteSpace(name) ? $"Spelare {i}" : name));
            }

            CardDecks deck = new CardDecks();
            Game game = new Game(players, deck);
            game.Start();

            Console.WriteLine($"Översta kortet: {game.TopCard}");

            Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}