using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    static class Player
    {
        public static int Cash;

        public static void NewWallet()
        {
            Cash = 100;
        }

        public static void BetAmount(int amount)
        {
            Cash -= amount;
        }

        public static int GetWallet()
        {
            return Cash;
        }

        public static void WinAmount(int amount)
        {
            Cash += amount;
        }

    }
}
