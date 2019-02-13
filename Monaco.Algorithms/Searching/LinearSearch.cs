using System;
using System.Collections.Generic;

namespace Monaco.Algorithms.Searching
{
    public static class LinearSearch
    {
        /// <summary>
        /// Finds the first occurance of an item using a naive linear search
        /// </summary>
        /// <returns>The index if found or -1 if not found</returns>
        public static int FindFirstItem<T>(IList<T> list, T item) where T : IEquatable<T>
        {
            if (list is null)
                throw new NullReferenceException(nameof(list));

            for (int i = 0; i < list.Count; i++)
                if (list[i].Equals(item))
                    return i;
            return -1;
        }

        /// <summary>
        /// Finds all occurences of an item using a naive linear search
        /// </summary>
        /// <returns>An enumerable of indices or an empty enumerable if not found</returns>
        public static IEnumerable<int> FindItem<T>(IList<T> list, T item) where T : IEquatable<T>
        {
            if (list is null)
                throw new NullReferenceException(nameof(list));

            for (int i = 0; i < list.Count; i++)
                if (list[i].Equals(item))
                    yield return i;
        }

        /// <summary>
        /// Finds the first occurance of a sequence using a naive linear search
        /// O(m*n) runtime complexity
        /// </summary>
        /// <returns>The index if found or -1 if not found</returns>
        public static int FindFirstSequence<T>(IList<T> list, IList<T> searchItems) where T: IEquatable<T>
        {
            if (list is null || searchItems is null)
                throw new NullReferenceException();

            if (list.Count == 0 || searchItems.Count == 0)
                return -1;

            int j = 0;
            for(int i = 0; i < list.Count - (searchItems.Count - 1); i++)
            {
                for(j = 0; j < searchItems.Count; j++)
                {
                    if (!list[i+j].Equals(searchItems[j]))
                        break;
                }

                if (j == searchItems.Count)
                    return i;
            }

            return -1;
        }
    }
}
