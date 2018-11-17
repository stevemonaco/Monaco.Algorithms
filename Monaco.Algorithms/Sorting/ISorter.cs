using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Sorting
{
    public enum SortOrder { Ascending = 1, Descending = 2 }

    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> input, SortOrder sortOrder = SortOrder.Ascending);
        void Sort(IList<T> input, SortOrder sortOrder, IComparer<T> comparer);
    }
}
