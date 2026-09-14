using System;
using System.Collections.Generic;
using System.Text;

namespace uno_csharp_project
{
    internal class CardDecks
    {
        private List<Card> cards = new List<Card>();

        public CardDecks()
        {
            BuildDeck();
            Shuffle();
        }

        public int Count => cards.Count;

        private void BuildDeck()
        {
            CardColor[] colors = { CardColor.Red, CardColor.Yellow, CardColor.Green, CardColor.Blue };

            foreach (CardColor color in colors)
            {
                // En 0:a per färg
                cards.Add(new Card(color, CardType.Number, 0));

                // Två av varje 1-9 per färg
                for (int number = 1; number <= 9; number++)
                {
                    cards.Add(new Card(color, CardType.Number, number));
                    cards.Add(new Card(color, CardType.Number, number));
                }

                // Två av varje specialkort per färg
                cards.Add(new Card(color, CardType.Skip));
                cards.Add(new Card(color, CardType.Skip));

                cards.Add(new Card(color, CardType.Reverse));
                cards.Add(new Card(color, CardType.Reverse));

                cards.Add(new Card(color, CardType.DrawTwo));
                cards.Add(new Card(color, CardType.DrawTwo));
            }

            // Wild-kort (4 av varje, ingen fast färg)
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card(CardColor.Wild, CardType.Wild));
                cards.Add(new Card(CardColor.Wild, CardType.WildDrawFour));
            }
        }

        private void Shuffle()
        {
            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Draghögen är tom!");
            }

            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }

        public Card DrawTopCard()
        {
            return null;
        }
    }
}
