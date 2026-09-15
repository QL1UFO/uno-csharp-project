using System;

namespace uno_csharp_project
{
    public class Card
    {
        public CardColor Color { get; private set; }
        public CardType Type { get; set; }
        public int? Number { get; set; }

        // Konstruktor för talkort (t.ex. Red 0, Yellow 5)
        public Card(CardColor color, CardType type, int number)
        {
            Color = color;
            Type = type;
            Number = number;
        }

        // Konstruktor för kort utan siffror (t.ex. Skip, DrawTwo, Wild)
        public Card(CardColor color, CardType type)
        {
            Color = color;
            Type = type;
            Number = null;
        }

        // Metod för att skriva ut kortet i konsolen med rätt färg
        public void PrintCard()
        {
            switch (Color)
            {
                case CardColor.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                case CardColor.Yellow: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case CardColor.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                case CardColor.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                case CardColor.Wild: Console.ForegroundColor = ConsoleColor.Magenta; break;
            }

            string cardText = Number.HasValue ? $"{Color} {Number}" : $"{Color} {Type}";
            Console.WriteLine(cardText);

            Console.ResetColor(); // Återställ textfärgen
        }
    }
}