using System;
using System.Collections.Generic;
using System.Linq;

namespace Monaco.Algorithms.Sequences
{
    /// <summary>
    /// Algorithm implementation to find the Longest Increasing Subsequence
    /// </summary>
    /// <remarks>Approach adapted largely from https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/ </remarks>
    /// <typeparam name="T"></typeparam>
    public class LongestIncreasingSubsequence
    {
        /// <summary>
        /// Returns the LIS length using a dynamic programming method
        /// O(n^2) runtime complexity
        /// O(n) memory complexity
        /// </summary>
        public static int LisLengthDynamic<T>(IList<T> items) where T : IComparable<T>
        {
            if (items is null)
                throw new NullReferenceException();

            if (items.Count == 0)
                return 0;

            int[] table = new int[items.Count];
            var comparer = Comparer<T>.Default;

            for (int i = 1; i < items.Count; i++)
                for (int j = 0; j < i; j++)
                    if (comparer.Compare(items[j], items[i]) < 0 && table[i] < (table[j] + 1))
                        table[i] = 1 + table[j];

            return table.Max() + 1;
        }

        /// <summary>
        /// Returns all subsequences using a dynamic programming method
        /// O(n^2) runtime complexity
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<IList<T>> LisListDynamic<T>(IList<T> items) where T : IComparable<T>
        {
            if (items is null)
                throw new NullReferenceException();

            if (items.Count == 0)
                return new List<List<T>>();

            var table = new List<List<T>>(items.Count);

            for (int i = 0; i < items.Count; i++)
                table.Add(new List<T>());

            table[0].Add(items[0]);

            var comparer = Comparer<T>.Default;

            // Construct LIS table
            for (int i = 1; i < items.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(items[j], items[i]) < 0 && (table[i].Count < table[j].Count + 1))
                    {
                        table[i].Clear();
                        table[i].AddRange(table[j]);
                    }
                }

                table[i].Add(items[i]);
            }

            // Return the list(s) which has the most entries
            int max = table.Select(x => x.Count).Max();
            return table.Where(x => x.Count == max);
        }
    }
}
