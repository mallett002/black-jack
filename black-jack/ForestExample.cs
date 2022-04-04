using System;
namespace black_jack
{
    class ForestExample
    {
        private string biome;
        public string Name { get; set; }
        public int Trees { get; set; }
        public int Age { get; private set; }

        public ForestExample(string name, string biome)
        {
            this.Name = name;
            this.Biome = biome;
            Age = 0;
        }

        public ForestExample(string name) : this(name, "Unknown")
        {
            Console.WriteLine("Country property not specified. Value defaulted to 'Unknown'.");
        }

        public string Biome
        {
            get { return biome; }
            set
            {
                if (value == "Tropical" ||
                    value == "Temperate" ||
                    value == "Boreal")
                {
                    biome = value;
                }
                else
                {
                    biome = "Unknown";
                }
            }
        }


        public int Grow()
        {
            Trees += 30;
            Age += 1;
            return Trees;
        }

        public int Burn()
        {
            Trees -= 20;
            Age += 1;
            return Trees;
        }

    }
}
