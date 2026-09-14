using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace uno_csharp_project
{
    internal class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        // Lägger till ett kort i spelarens hand, t.ex. när man drar från leken
        public void AddCard(Card card)
        {
            Hand.Add(card);
        }

        // Returnerar alla kort i handen som går att spela på det aktuella kortet på spelhögen
        public List<Card> GetPlayableCards(Card topCard)
        {
            return Hand.Where(card => card.CanBePlayedOn(topCard)).ToList();
        }

        // Tar bort och returnerar ett specifikt kort ur handen (t.ex. det spelaren valt att spela)
        public Card PlayCard(Card card)
        {
            if (!Hand.Remove(card))
            {
                throw new InvalidOperationException("Kortet finns inte i spelarens hand.");
            }

            return card;
        }

        // Spelaren har vunnit när handen är tom
        public bool HasWon()
        {
            return Hand.Count == 0;
        }

        public override string ToString()
        {
            return $"{Name} ({Hand.Count} kort)";
        }
    }
}
