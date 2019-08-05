using System;
using System.Collections.Generic;
using Monaco.Algorithms.Extensions;

namespace Monaco.Algorithms.Sorting
{
    /// <summary>
    /// Quicksorts a collection.
    /// Implementation largely ported from Sedgewick https://algs4.cs.princeton.edu/23quicksort/Quick.java.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Monaco.Algorithms.Sorting.SorterBase{T}" />
    public class QuickSorter<T> : SorterBase<T> where T : IComparable<T>
    {
        Func<T, T, bool> shouldSwap = null;

        public override void Sort(IList<T> list, SortOrder sortOrder, IComparer<T> comparer)
        {
            if (list is null)
                throw new NullReferenceException();

            if (list.Count == 0 || list.Count == 1)
                return;

            if (sortOrder == SortOrder.Ascending)
                shouldSwap = (a, b) => comparer.Compare(a, b) > 0;
            else if (sortOrder == SortOrder.Descending)
                shouldSwap = (a, b) => comparer.Compare(a, b) < 0;

            QuickSort(list, sortOrder, comparer, 0, list.Count -1);
        }

        private void QuickSort(IList<T> list, SortOrder sortOrder, IComparer<T> comparer, int start, int end)
        {
            if (end <= start)
                return;

            int partitionIndex = Partition(list, sortOrder, comparer, start, end);
            QuickSort(list, sortOrder, comparer, start, partitionIndex - 1);
            QuickSort(list, sortOrder, comparer, partitionIndex + 1, end);
        }

        private int Partition(IList<T> list, SortOrder sortOrder, IComparer<T> comparer, int start, int end)
        {
            int i = start + 1;
            int j = end;
            var val = list[start];

            while(true)
            {
                while(!shouldSwap(list[i], val))
                {
                    i++;
                    if (i >= end)
                        break;
                }

                while(!shouldSwap(val, list[j]))
                {
                    j--;
                    if (j <= start)
                        break;
                }

                if (i >= j)
                    break;

                list.Swap(i, j);
            }

            list.Swap(start, j);

            return j;
        }
    }
}
