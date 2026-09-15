using System;
using System.Collections.Generic;
using System.Text;


namespace uno_csharp_project
{
    internal enum CardColor
    {
        Red,
        Yellow,
        Green,
        Blue,
        Wild   // används för Wild och Wild Draw Four, som inte har en fast färg från början
    }

    internal enum CardType
    {
        Number,
        Skip,
        Reverse,
        DrawTwo,
        Wild,
        WildDrawFour
    }

    internal class Card
    {
        public CardColor Color { get; private set; }
        public CardType Type { get; }
        public int? Number { get; }   // bara relevant om Type == Number, annars null

        public Card(CardColor color, CardType type, int? number = null)
        {
            Color = color;
            Type = type;
            Number = number;
        }

        public override string ToString()
        {
            return Type == CardType.Number
                ? $"{Color} {Number}"
                : $"{Color} {Type}";
        }

        public bool CanBePlayedOn(Card topCard)
        {
            if (Type == CardType.Wild || Type == CardType.WildDrawFour)
                return true; // Wild-kort går alltid att lägga

            if (Color == topCard.Color)
                return true;

            if (Type == CardType.Number && topCard.Type == CardType.Number)
                return Number == topCard.Number;

            return Type == topCard.Type; // t.ex. Skip mot Skip, Reverse mot Reverse
        }

        public void SetChosenColor(CardColor color)
        {
            if (Type != CardType.Wild && Type != CardType.WildDrawFour)
                throw new InvalidOperationException("Bara Wild-kort kan få en vald färg.");

            Color = color;
        }
    }
}
