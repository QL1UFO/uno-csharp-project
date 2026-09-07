using System;
using System.Collections.Generic;
using System.Text;

using System;

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
        public CardColor Color { get; set; }
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
    }
}
