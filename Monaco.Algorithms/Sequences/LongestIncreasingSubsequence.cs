using System;
using System.Collections.Generic;
using System.Linq;

namespace Monaco.Algorithms.Sequences
{
    public class LongestIncreasingSubsequence<T> where T : IComparable<T>
    {
        /// <summary>
        /// Returns the LIS length using a dynamic programming method
        /// O(n^2) runtime complexity
        /// O(n^2) memory complexity
        /// </summary>
        public static int LisLengthDynamic(IList<T> items)
        {
            if (items is null)
                throw new NullReferenceException();

            if (items.Count == 0)
                return 0;

            int[] table = new int[items.Count];
            for (int i = 0; i < items.Count; i++)
                table[i] = 1;

            var comparer = Comparer<T>.Default;

            for (int i = 1; i < items.Count; i++)
                for (int j = 0; j < i; j++)
                    if (comparer.Compare(items[j], items[i]) < 0 && table[i] < (table[j] + 1))
                        table[i] = 1 + table[j];

            return table.Max();
        }

        public static IEnumerable<IList<T>> LisListDynamic(IList<T> items)
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
