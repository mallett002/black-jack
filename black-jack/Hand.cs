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
            Cards.Add(card);
        }

        public override string ToString()
        {
            return String.Join(", ", Cards);
        }
    }
}
