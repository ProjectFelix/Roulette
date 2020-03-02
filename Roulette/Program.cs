using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Player.NewWallet();
            
            
            RouletteBoard board = new RouletteBoard();
            board.TestStuff();
            
            
            string menu = $"What would you like to do?\n-1. Place bets\n-2. Roll for that big money\n-3. Exit";
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"Cash: {Player.GetWallet()}");
                Console.WriteLine(menu);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        board.PlaceBet();
                        break;
                    case "2":
                        board.FindWinningBets();
                        break;
                    case "3":
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
