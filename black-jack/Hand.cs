using System.Collections.Generic;

namespace black_jack
{
    public class Hand
    {
        public List<Card> cards { get; set; }

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCardToHand(Card card)
        {
            cards.Add(card);
        }
    }
}
