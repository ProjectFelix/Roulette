using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Roulette
{
    class RouletteBoard
    {
        public int[,] Numbers = new int[3, 12] {
            {1,4,7,10,13,16,19,22,25,28,31,34 },
            {2,5,8,11,14,17,20,23,26,29,32,35 },
            {3,6,9,12,15,18,21,24,27,30,33,36 }
        };

        
        public int[] Row1 = new int[] { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        public int[] Row2 = new int[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        public int[] Row3 = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        public int[][] Board = new int[4][];

        public string WinningNumber { get; set; }
        public string WinningColor { get; set; }

        public List<Bet> Bets { get; set; } = new List<Bet>();
        

        // Methods


        
        public void TestStuff()
        {
            for (int i = 0; i < 39; i++)
            {
                if (i == 37)
                {
                    WinningNumber = "0";
                    WinningColor = "Green";
                    
                }
                if (i == 38)
                {
                    WinningNumber = "00";
                    WinningColor = "Green";
                }
                if (i < 37)
                {
                    WinningNumber = i.ToString();
                    WinningColor = ((i % 10) % 2 == 0) ? "Black" : "Red";

                }
                Console.WriteLine($"{WinningNumber} - {WinningColor}");
            }
        }
        public void GetWinner()
        {
            Random rand = new Random();
            int winner = rand.Next(0,38);
            if (winner == 37)
            {
                WinningNumber = "0";
                WinningColor = "Green";
            }
            if (winner == 38)
            {
                WinningNumber = "00";
                WinningColor = "Green";
            }
            if (winner < 37)
            {
                WinningNumber = winner.ToString();
                WinningColor = ((winner % 9) % 2 == 0) ? "Black" : "Red";
                
            }
            
            Console.WriteLine($"The ball lands on the {WinningColor} {WinningNumber}!");
        }

        public void FindWinningBets()
        {
            GetWinner();
            foreach (Bet bet in Bets)
            {
                if (bet.Numbers.Contains(WinningNumber) || bet.Color == WinningColor)
                {
                    Console.WriteLine($"This {bet} won!");
                }
                else {
                    Console.WriteLine($"This {bet} lost.");
                };
            }
            Bets.Clear();
        }

        public void PlaceBet()
        {
            Console.WriteLine($"Cash: {Player.GetWallet()}");
            string menu = "Which type of bet would you like to place?\n-1. Number\n-2. Evens/Odds\n-3. Reds/Blacks\n-4. Lows/Highs\n-5. Dozens\n-6. Columns\n-7. Street\n-8. 6 Numbers\n-9. Split\n-10. Corner\n-11. Done";
            bool placingBets = true;
            int betAmount;
            while (placingBets)
            {
                Console.WriteLine(menu);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Which number would you like to place a bet on? (0 ,00 , 1-36)");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        Bets.Add(new Bet(input, "number", betAmount));
                        break;
                    case "2":
                        Console.WriteLine("Bet on which?\n-1. Evens\n-2. Odds");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        switch (input)
                        {
                            case "1":
                                Bets.Add(new Bet(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 }, "evens", betAmount));
                                break;
                            case "2":
                                Bets.Add(new Bet(new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 }, "odds", betAmount));
                                break;
                            default:
                                Console.WriteLine("Not a valid option.");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Which color?\n-1. Reds\n-2. Blacks");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        switch (input)
                        {
                            case "1":
                                Bets.Add(new Bet("Red", "color", betAmount));
                                break;
                            case "2":
                                Bets.Add(new Bet("Black", "color", betAmount));
                                break;
                            default:
                                Console.WriteLine("Not valid option");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Which range?\n-1. Lows\n-2. Highs");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        switch (input)
                        {
                            case "1":
                                Bets.Add(new Bet(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18 }, "lows", betAmount));
                                break;
                            case "2":
                                Bets.Add(new Bet(new int[] { 19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36 }, "highs", betAmount));
                                break;
                            default:
                                Console.WriteLine("Not valid option");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Which dozen?\n-1. 1-12\n-2. 13-24\n-3. 25-36");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        switch (input)
                        {
                            case "1":
                                Bets.Add(new Bet(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12 }, "1-12", betAmount));
                                break;
                            case "2":
                                Bets.Add(new Bet(new int[] { 13,14,15,16,17,18,19,20,21,22,23,24 }, "13-24", betAmount));
                                break;
                            case "3":
                                Bets.Add(new Bet(new int[] { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 }, "25-36", betAmount));
                                break;
                            default:
                                Console.WriteLine("Not valid option");
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Which column?\n-1. 1st (1-34)\n-2. 2nd (2-35)\n-3. 3rd (3-36)");
                        input = Console.ReadLine();
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        switch (input)
                        {
                            case "1":
                                Bets.Add(new Bet(Row1, "Column 1", betAmount));
                                break;
                            case "2":
                                Bets.Add(new Bet(Row2, "Column 2", betAmount));
                                break;
                            case "3":
                                Bets.Add(new Bet(Row3, "Column 3", betAmount));
                                break;
                            default:
                                Console.WriteLine("Not valid option", betAmount);
                                break;
                        }
                        break;
                    case "7":
                        Console.WriteLine("Which row?\n-1. 1-3\n-2. 4-6\n-3. 7-9\n-4. 10-12\n-5. 13-15\n-6. 16-18\n-7. 19-21\n-8. 22-24\n-9. 25-27\n-10. 28-30\n-11. 31-33\n-12. 34-36");
                        input = Console.ReadLine();
                        if (int.Parse(input) > 12 || int.Parse(input) < 0) Console.WriteLine("Invalid");
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        Bets.Add(new Bet(new int[] { Numbers[0, int.Parse(input)-1], Numbers[1, int.Parse(input)-1], Numbers[2, int.Parse(input)-1] }, "Row", betAmount));
                
                        break;
                    case "8":
                        Console.WriteLine("Which rows?\n-1. 1-6\n-2. 7-12\n-3. 13-18\n-4. 19-24\n-5. 25-30\n-6. 31-36");
                        int inputnum = int.Parse(Console.ReadLine());
                        if (inputnum > 6 || inputnum < 0) Console.WriteLine("Invalid");
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        IEnumerable<int> numbers = Enumerable.Range(1 + (6 * (inputnum - 1)), 6);
                        Bets.Add(new Bet(numbers.ToArray(), "six", betAmount));
                        break;
                    case "9":
                        Console.WriteLine("Select a number 1-36");
                        int userInput = int.Parse(Console.ReadLine()) - 1;
                        int ux = userInput % 3;
                        int uy = userInput / 3;

                        //Console.WriteLine($"{userInput} located at {ux},{uy}");
                        //Console.WriteLine($"{Numbers[ux, uy]}");
                        List<int> neighbor = new List<int>();
                        for (int i = -1; i < 2; i+=2)
                        {

                            if (ux + i >= 0 && ux + i < 3)
                            {
                                neighbor.Add(Numbers[ux + i, uy]);
                            } 
                            if (uy + i >= 0 && uy + i < 12)
                            {
                                neighbor.Add(Numbers[ux, uy + i]);
                            }
                            
                        }
                        Console.WriteLine("Which number to split with?");
                        int j = 1;
                        foreach (int num in neighbor)
                        {
                            Console.WriteLine($"{j}. Between {userInput + 1} and {num}.");
                            j++;
                        }
                        inputnum = int.Parse(Console.ReadLine());
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        Bets.Add(new Bet(new int[] { userInput + 1, neighbor[inputnum-1] }, "split", betAmount));
                        break;
                    case "10":
                        Console.WriteLine("Pick a number that the corner is on:");
                        int inputCorner = int.Parse(Console.ReadLine());
                        int x = (inputCorner - 1) % 3;
                        int y = (inputCorner - 1) / 3;
                        List<List<int>> quad = new List<List<int>>();
                        List<int> pairs = new List<int>();
                        for (int i = -1; i < 2; i += 2)
                        {
                            if (x+i >=0 && x+i < 3)
                            {
                                
                                
                                for (int jc = -1; jc < 2; jc += 2)
                                {
                                    if (y+jc >= 0 && y+jc < 12)
                                    {
                                        pairs.Add(inputCorner);
                                        pairs.Add(Numbers[x + i, y]);
                                        pairs.Add(Numbers[x, y + jc]);
                                        pairs.Add(Numbers[x + i, y + jc]);
                                        Console.WriteLine("Adding a corner set");
                                        quad.Add(pairs);
                                        pairs = new List<int>();
                                        
                                    }
                                }
                            }
                            
                        }
                        int k = 1;
                        foreach (List<int> p in quad)
                        {
                            string output = $"{k}. Corner set: ";
                            foreach (int n in p)
                            {
                                output += n.ToString() + " ";
                            }
                            Console.WriteLine(output);
                            k++;
                        }
                        Console.WriteLine("Which set do you want to bet on?\n");
                        userInput = int.Parse(Console.ReadLine());
                        Console.WriteLine("How much would you like to bet?\n");
                        betAmount = int.Parse(Console.ReadLine());
                        if (betAmount > Player.Cash || betAmount <= 0) Console.WriteLine("Come on, now. You can't bet that");
                        Bets.Add(new Bet(quad[userInput-1].ToArray(), "corner", betAmount));
                        break;
                    case "11":
                        placingBets = false;
                        break;
                    default:
                        break;
                }

            }
        }
        
    }
}
