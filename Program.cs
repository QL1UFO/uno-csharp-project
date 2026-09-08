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
            CardDecks deck = new CardDecks();
            Console.WriteLine($"Antal kort i leken: {deck.Count}");

            Card drawnCard = deck.Draw();
            Console.WriteLine($"Draget kort: {drawnCard}");
            Console.WriteLine($"Kort kvar: {deck.Count}");
            
        }
    }
}