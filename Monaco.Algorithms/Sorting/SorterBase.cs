using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Sorting
{
    public abstract class SorterBase<T> : ISorter<T> where T : IComparable<T>
    {
        public virtual void Sort(IList<T> input, SortOrder sortOrder = SortOrder.Ascending)
        {
            Sort(input, sortOrder, Comparer<T>.Default);
        }

        public abstract void Sort(IList<T> input, SortOrder sortOrder, IComparer<T> comparer);
    }
}
