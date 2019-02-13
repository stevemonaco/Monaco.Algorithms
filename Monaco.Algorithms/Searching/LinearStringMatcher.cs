using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Searching
{
    /// <summary>
    /// Implementation of a naive, linear string matching algorithm
    /// O(m*n) runtime complexity
    /// </summary>
    public class LinearStringMatcher : IStringMatcher
    {
        /// <summary>
        /// Finds the first occurance of the pattern in the text
        /// </summary>
        /// <returns>The index if found or -1 if not found</returns>
        public int FindFirst(string text, string pattern, int startIndex = 0)
        {
            if (text is null || pattern is null)
                throw new NullReferenceException();

            for (int i = startIndex; i < text.Length - pattern.Length + 1; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (text[i+j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Finds all occurances of the pattern in the text
        /// </summary>
        /// <returns>An enumerable of indices or an empty enumerable if not found</returns>
        public IEnumerable<int> FindAll(string text, string pattern, int startIndex = 0)
        {
            if (text is null || pattern is null)
                throw new NullReferenceException();

            for (int i = startIndex; i < text.Length - pattern.Length + 1; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (text[i+j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    yield return i;
            }
        }
    }
}
