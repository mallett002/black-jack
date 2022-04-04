using System;
namespace black_jack
{
    public class Card
    {
        public string Suite { get; set; }
        public string Name { get; set; }
        int CardValue { get; set; }

        public Card(string suite, string name, int cardValue)
        {
            Suite = suite;
            Name = name;
            CardValue = cardValue;
        }

        public override string ToString()
        {
            return $"{Name} of {Suite}";
        }
    }
}
