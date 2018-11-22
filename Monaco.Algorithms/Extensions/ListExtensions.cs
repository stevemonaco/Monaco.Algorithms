using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Randomly shuffles the list using a Fisher-Yates shuffle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="random">A seeded instance of Random</param>
        public static void RandomShuffle<T>(this IList<T> list, Random random)
        {
            for(int n = list.Count - 1; n > 0; n--)
            {
                int swapIndex = random.Next(0, n);
                var temp = list[n];
                list[n] = list[swapIndex];
                list[swapIndex] = temp;
            }
        }

        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
