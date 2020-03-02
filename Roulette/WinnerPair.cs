using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    class WinnerPair
    {
        public string Color { get; set; }
        public string Number { get; set; }

        public Tuple<string, string> Winner { get; }

        public WinnerPair(int number, string color)
        {
            Color = color;
            Number = number.ToString();
            Winner = new Tuple<string, string>(Color, Number);
        }
    }
}
