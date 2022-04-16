using System;
using System.Collections.Generic;

namespace black_jack
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCardToHand(Card card)
        {
            if (card.Name == "A")
            {
                Cards.Add(card);
            }
            else
            {
                Cards.Insert(0, card);
            }
        }

        public override string ToString()
        {
            return String.Join(", ", Cards);
        }
    }
}
