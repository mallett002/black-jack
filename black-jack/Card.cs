using System;
namespace black_jack
{
    public class Card
    {
        public string Suite { get; set; }
        public string Name { get; set; }

        public Card(string suite, string name)
        {
            Suite = suite;
            Name = name;
        }

        public override string ToString()
        {
            return $"[{Name} of {Suite}]";
        }
    }
}
