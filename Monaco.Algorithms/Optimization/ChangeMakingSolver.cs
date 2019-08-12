using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monaco.Algorithms.Optimization
{
    /// <summary>
    /// Solutions for the change-making problem where a minimal amount of coins must be found to sum to the specified amount
    /// </summary>
    public static class ChangeMakingSolver
    {
        public static IEnumerable<(decimal, int)> GreedySolve(IEnumerable<decimal> coinValues, decimal changeAmount)
        {
            var coins = coinValues.OrderByDescending(x => x).Select(x => (Value: x, Count: 0)).ToList();
            var amountLeft = changeAmount;
            var coinResult = new List<(decimal, int)>();

            for(int i = 0; i < coins.Count; i++)
            {
                coins[i] = (coins[i].Value, (int) (amountLeft / coins[i].Value));
                amountLeft -= coins[i].Count * coins[i].Value;
            }

            if(amountLeft != 0)
                coins[^1] = (coins[^1].Value, coins[^1].Count + Convert.ToInt32(0.5m + coins[^1].Value / amountLeft));

            return coins;
        }

        public static IEnumerable<(decimal, int)> DynamicSolve(IEnumerable<decimal> coinValues, decimal changeAmount)
        {
            var coins = coinValues.OrderByDescending(x => x).Select(x => (Value: x, Count: 0)).ToList();
            var amountLeft = changeAmount;
            var coinResult = new List<(decimal, int)>();



            return coins;
        }
    }
}
