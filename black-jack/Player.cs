namespace black_jack
{
    public class Player
    {
        public string Name { get; set; }
        public Hand PlayerHand { get; set; }

        public Player()
        {
            PlayerHand = new Hand();
        }

        public void AddCard(Card card)
        {
            PlayerHand.AddCardToHand(card);
        }
    }
}
