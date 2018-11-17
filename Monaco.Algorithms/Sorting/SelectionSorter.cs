using System;
using System.Collections.Generic;

namespace Monaco.Algorithms.Sorting
{
    public class SelectionSorter<T> : SorterBase<T> where T : IComparable<T>
    {
        public override void Sort(IList<T> input, SortOrder sortOrder, IComparer<T> comparer)
        {
            if (input is null)
                throw new NullReferenceException();

            if (input.Count == 0 || input.Count == 1)
                return;

            Func<T, T, bool> shouldSwap = null;

            if (sortOrder == SortOrder.Ascending)
                shouldSwap = (a, b) =>
                {
                    if (comparer.Compare(a, b) > 0)
                        return true;
                    return false;
                };
            else if (sortOrder == SortOrder.Descending)
                shouldSwap = (a, b) =>
                {
                    if (comparer.Compare(a, b) < 0)
                        return true;
                    return false;
                };

            for (int i = 0; i < input.Count; i++)
            {
                int swapIndex = 0;
                for (int j = 1; j < input.Count - i; j++)
                {
                    if (shouldSwap(input[j], input[swapIndex]))
                        swapIndex = j;
                }

                var temp = input[swapIndex];
                input[swapIndex] = input[input.Count - i - 1];
                input[input.Count - i - 1] = temp;
            }
        }
    }
}
