using System;
using System.Collections.Generic;

namespace black_jack
{
    public class Game
    {

        public bool GameOver { get; set; }
        public List<Card> Deck { get; set; }
        private string[] suites = { "Hearts", "Clubs", "Spades", "Diamonds" };
        private string[] names = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public Player PlayerOne { get; set; }
        public Player Dealer { get; set; }
        private Random Rando { get; set;}

        public Game(string playerName)
        {
            Rando = new Random();
            GameOver = false;

            PlayerOne = new Player();
            PlayerOne.Name = playerName;

            Dealer = new Player();
            Dealer.Name = "Bob the dealer";

            Deck = new List<Card>();

            foreach(string suite in suites)
            {
                foreach(string name in names)
                {

                    int cardValue;

                    bool canParse = Int32.TryParse(name, out cardValue);

                    if (!canParse)
                    {
                        if (name == "A")
                        {
                            cardValue = 1;
                        }
                        else
                        { cardValue = 10; }
                    }

                    Card card = new Card(suite, name, cardValue);
                    Deck.Add(card);
                }
            }
        }

        private void CreateHandForPlayer(Player player, int cardOneIndex, int cardTwoIndex)
        {
            Card cardOne = Deck[cardOneIndex];
            Card cardTwo = Deck[cardTwoIndex];

            player.AddCard(cardOne);
            player.AddCard(cardTwo);

            Deck.RemoveAt(cardOneIndex);
            Deck.RemoveAt(cardTwoIndex);
        }

        public void CreateHands()
        {
            int cardOneIndex = Rando.Next(Deck.Count);
            int cardTwoIndex = Rando.Next(Deck.Count);

            CreateHandForPlayer(PlayerOne, cardOneIndex, cardTwoIndex);

            int cardThreeIndex = Rando.Next(Deck.Count);
            int cardFourIndex = Rando.Next(Deck.Count);

            CreateHandForPlayer(Dealer, cardThreeIndex, cardFourIndex);

            Console.WriteLine(Deck.Count);
        }

        public override string ToString()
        {
            return $"Player one: {PlayerOne.Name}; Dealer: {Dealer.Name}";
        }
    
    }

}
