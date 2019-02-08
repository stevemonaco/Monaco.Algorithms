using System;
using System.Collections.Generic;
using System.Linq;

namespace Monaco.Algorithms.Sorting
{
    public class MergeSorter<T> : SorterBase<T> where T : IComparable<T>
    {
        Func<T, T, bool> shouldSwap = null;

        public override void Sort(IList<T> input, SortOrder sortOrder, IComparer<T> comparer)
        {
            if (input is null)
                throw new NullReferenceException();

            if (input.Count == 0 || input.Count == 1)
                return;

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

            var sorted = MergeSort(input);

            for (int i = 0; i < sorted.Count; i++)
                input[i] = sorted[i];
        }

        private IList<T> MergeSort(IList<T> input)
        {
            if (input.Count <= 1)
                return input;

            int leftSize = input.Count / 2;
            int rightSize = input.Count - leftSize;

            IList<T> left = new List<T>(leftSize);
            IList<T> right = new List<T>(rightSize);

            for (int i = 0; i < leftSize; i++)
                left.Add(input[i]);

            for (int i = 0; i < rightSize; i++)
                right.Add(input[i + leftSize]);

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> merged = new List<T>(left.Count + right.Count);

            int idx = 0;
            int idy = 0;
            int mergeIndex = 0;

            while (mergeIndex < (left.Count + right.Count))
            {
                if(idx >= left.Count)
                {
                    merged.Add(right[idy]);
                    idy++;
                }
                else if(idy >= right.Count)
                {
                    merged.Add(left[idx]);
                    idx++;
                }
                else if(shouldSwap(left[idx], right[idy]))
                {
                    merged.Add(right[idy]);
                    idy++;
                }
                else
                {
                    merged.Add(left[idx]);
                    idx++;
                }

                mergeIndex++;
            }

            return merged;
        }
    }
}
