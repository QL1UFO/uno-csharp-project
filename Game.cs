using System.Collections.Generic;

namespace uno_csharp_project
{
    internal class Game
    {
        private readonly List<Player> players;
        private readonly CardDecks deck;
        private readonly List<Card> discardPile = new List<Card>();

        private int currentPlayerIndex = 0;
        private int direction = 1; // 1 = medurs, -1 = moturs

        public Game(List<Player> players, CardDecks deck)
        {
            this.players = players;
            this.deck = deck;
        }

        public Card TopCard => discardPile[^1];
        private Player CurrentPlayer => players[currentPlayerIndex];

        public void Start()
        {
            foreach (var player in players)
                player.DrawCards(deck.DrawMultiple(7));

            discardPile.Add(deck.Draw()); // OBS: kan bli Wild — hantera det senare
        }

        private void AdvanceTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + direction + players.Count) % players.Count;
        }

        // TODO: PlayTurn() — visa TopCard, be CurrentPlayer välja spelbart kort eller dra
        // TODO: ApplyEffect(Card) — Skip/Reverse/DrawTwo/Wild/WildDrawFour
        // TODO: CheckWinner() — kolla HasWon efter varje drag
    }
}