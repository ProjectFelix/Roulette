using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    class Bet
    {
        public List<string> Numbers { get; set; } = new List<string>();
        public string Color { get; set; }

        public string Type { get; set; }
        
        public int Amount { get; set; }

        public double ReturnRate { get; set; }

        public Bet(string input, string type, int amount)
        {
            Type = type;
            if (type == "number") Numbers.Add(input);
            if (type == "color") Color = input;
            Amount = amount;
            Player.BetAmount(amount);
        }

        public Bet(int[] nums, string type, int amount)
        {
            Type = type;
            foreach (int num in nums)
            {
                Numbers.Add(num.ToString());
            }
        }

        public override string ToString()
        {
            string numbers = "";
            for (int i = 0; i < Numbers.Count-1; i++ )
            {
                numbers += Numbers[i] + ", ";
            }
            if (Numbers.Count > 0) numbers += Numbers[Numbers.Count - 1];
            return $"bet on {Type} {numbers}{Color}";
        }
    }
}
