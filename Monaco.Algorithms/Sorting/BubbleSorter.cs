using System;
using System.Collections.Generic;

namespace Monaco.Algorithms.Sorting
{
    public class BubbleSorter<T> : SorterBase<T> where T : IComparable<T>
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

            for (int i = 1; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count - i; j++)
                {
                    if(shouldSwap(input[j], input[j+1]))
                    {
                        var temp = input[j];
                        input[j] = input[j+1];
                        input[j+1] = temp;
                    }
                }
            }
        }
    }
}
