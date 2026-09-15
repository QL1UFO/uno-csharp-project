using System;
namespace uno_csharp_project
{
    public static class Program
    {
        private static int GetNumberOfPlayers()
        {
            int players;

            while (true)
            {
                Console.WriteLine("Skriv in antal spelare (2-4):");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out players) && players >= 2 && players <= 4)
                {
                    return players;
                }

                Console.WriteLine("Ogiltigt antal. Ange ett tal mellan 2 och 4.");
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

        }
    }
}