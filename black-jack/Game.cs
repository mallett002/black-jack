using System;
using System.Collections.Generic;

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

        private void CreateHands()
        {
            int cardOneIndex = Rando.Next(Deck.Count);
            int cardTwoIndex = Rando.Next(Deck.Count);


            CreateHandForPlayer(PlayerOne, cardOneIndex, cardTwoIndex);

            int cardThreeIndex = Rando.Next(Deck.Count);
            int cardFourIndex = Rando.Next(Deck.Count);

            CreateHandForPlayer(Dealer, cardThreeIndex, cardFourIndex);

            Console.WriteLine($"Your hand: {PlayerOne.PlayerHand}");
        }

        private static int CompareCardsBySuite()
        {
            return 5;
        }

        private void CalculateValue()
        {
            Console.WriteLine("Calculating hand value");

            int playerHandValue = 0;
            PlayerOne.PlayerHand.Cards.Sort(delegate (Card first, Card second) // Put the A's last
            {
                //if (first.PartName == null && second.PartName == null) return 0;
                //else if (x.PartName == null) return -1;
                //else if (y.PartName == null) return 1;
                //else return x.PartName.CompareTo(y.PartName);

                if (first.Name == "A")
                { return 1; }

                return -1;
            });

            foreach (Card card in PlayerOne.PlayerHand.Cards)
            {
                //    bool canParse = Int32.TryParse(card.Name, out int cardValue);

                //    if (!canParse)
                //    {
                //        if (card.Name == "A")
                //        {
                //            // 1 or 11
                //            if (playerHandValue + 11 > 21)
                //            {

                //            }

                //        }
                //        else // is face card, value is 10
                //        {
                //            playerHandValue += 10;
                //        }
                //    }
                //    else
                //    {
                //        playerHandValue += cardValue;
                //    }
                Console.WriteLine(card.Name);
            }
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
                    int cardIndex = Rando.Next(Deck.Count);
                    Card newCard = Deck[cardIndex];
                
                    PlayerOne.AddCard(newCard);

                    Deck.RemoveAt(cardIndex);
                    Deck.RemoveAt(cardIndex);

                    Console.WriteLine($"Your hand: {PlayerOne.PlayerHand}");

                    CalculateValue();

                    PromptAnotherCard();
                    return;
                }
                else if (res == "s")
                {
                    break;
                }
            } while (res != "H" && res != "s");

        }

        public void RunGame()
        {
            // Give you some cards
            // give dealer some cards
            CreateHands();
            PromptAnotherCard();

            // ask if you want another card until you say stop

            // once you say stop
            // creates the dealers hand
            // if the dealer is 18 or higher, stays
            // compares your hand with dealers
            // if you have higher card w/o going over 21, you win
            // if you win, print "you win the game" and set gameover to true;
        }

        public override string ToString()
        {
            return $"Player one: {PlayerOne.Name}; Dealer: {Dealer.Name}";
        }
    
    }

}
