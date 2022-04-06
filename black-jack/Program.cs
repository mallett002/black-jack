using System;


namespace black_jack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets play some Blackjack!");
            Console.WriteLine("Enter your name: ");

            string name = Console.ReadLine();

            Console.WriteLine($"Welcome to the game, {name}!");
            Console.WriteLine("Press \"Return\" to get started!");

            ConsoleKey startGameKey = Console.ReadKey().Key;

            if (startGameKey == ConsoleKey.Enter)
            {
                // Start the game
                Game game = new Game(name);

                game.RunGame();
            }
        }
    }
}
