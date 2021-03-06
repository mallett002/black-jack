using System;
using System.Collections.Generic;
using System.Linq;

namespace black_jack
{
    public class Game
    {

        public bool GameOver { get; set; }
        public string Winner { get; set; }
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
                    Card card = new Card(suite, name);
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

        private void CreateHands()
        {
            int cardOneIndex = Rando.Next(Deck.Count - 1);
            int cardTwoIndex = Rando.Next(Deck.Count - 1);
            CreateHandForPlayer(PlayerOne, cardOneIndex, cardTwoIndex);

            int cardThreeIndex = Rando.Next(Deck.Count - 1);
            int cardFourIndex = Rando.Next(Deck.Count - 1);
            CreateHandForPlayer(Dealer, cardThreeIndex, cardFourIndex);


            int dealerValue = CalculateValue(Dealer);

            while (dealerValue < 18)
            {
                int cardIndex = Rando.Next(Deck.Count - 1);
                Card card = Deck[cardIndex];

                Dealer.AddCard(card);
                dealerValue = CalculateValue(Dealer);
            }

            Console.WriteLine($"Your hand: {PlayerOne.PlayerHand}");

            if (dealerValue > 21)
            {
                Console.WriteLine($"Dealer went over, winner: {PlayerOne.Name}");

                GameOver = true;
            }
        }

        private int CalculateValue(Player player)
        {

            int totalValue = 0;

            player.PlayerHand.Cards.ForEach((card) =>
            {
                if (card.Name == "A")
                {
                    if (totalValue + 11 > 21)
                    {
                        totalValue++;
                    }
                    else
                    {
                        totalValue += 11;
                    }
                }
                else
                {
                    int cardValue;

                    bool canParse = Int32.TryParse(card.Name, out cardValue);

                    if (!canParse)
                    {
                        totalValue += 10;
                    }
                    else
                    {
                        totalValue += cardValue;
                    }
                }
            });

            return totalValue;
        }
            

        private void PromptAnotherCard()
        {
            Console.WriteLine($"Hit or Stay: h/s");

            string res;

            do
            {
                res = Console.ReadLine();

                if (res == "h")
                {
                    int cardIndex = Rando.Next(Deck.Count - 1);
                    Card newCard = Deck[cardIndex];
                
                    PlayerOne.AddCard(newCard);

                    Deck.RemoveAt(cardIndex);
                    Deck.RemoveAt(cardIndex);

                    Console.WriteLine($"Your hand: {PlayerOne.PlayerHand}");

                    int playerOneValue = CalculateValue(PlayerOne);

                    if (playerOneValue > 21)
                    {
                        Console.WriteLine($"{PlayerOne.Name}, you lost.");

                        GameOver = true;

                        return;
                    }

                    PromptAnotherCard();
                    return;
                }
                else if (res == "s")
                {
                    break;
                }
            } while (res != "h" && res != "s");
        }

        public void RunGame()
        {
            CreateHands();

            if (!GameOver)
            {
                PromptAnotherCard();

                int playerDiff = Math.Abs(CalculateValue(PlayerOne) - 21);
                int dealerDiff = Math.Abs(CalculateValue(Dealer) - 21);

                if (playerDiff > dealerDiff)
                {
                    Console.WriteLine($"{Dealer.Name} wins the game!");
                }
                else if (dealerDiff > playerDiff)
                {
                    Console.WriteLine($"{PlayerOne.Name}, you have won the game! Nicely done!");
                }
                else
                {
                    Console.WriteLine($"This game has ended in a draw!");
                }

                Console.WriteLine($"{Dealer.Name}'s hand: {Dealer.PlayerHand}");

                GameOver = true;
            }
        }

        public override string ToString()
        {
            return $"Player one: {PlayerOne.Name}; Dealer: {Dealer.Name}";
        }
    
    }

}
