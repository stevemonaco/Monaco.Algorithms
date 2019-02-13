using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Searching
{
    /// <summary>
    /// Implementation of Knuth-Morris-Pratt algorithm for string searching
    /// O(m+n) runtime complexity
    /// </summary>
    /// <remarks>Current implementation based upon http://www-igm.univ-mlv.fr/~lecroq/string/node8.html#SECTION0080
    /// Initial implementation based upon https://www.nayuki.io/page/knuth-morris-pratt-string-matching 
    /// but was found to do many more comparisons than a real KMP solution</remarks>
    public class KmpStringMatcher : IStringMatcher
    {
        private string lastPattern;
        private int[] lastTable;

        /// <summary>
        /// Builds a Kmp table from the provided pattern
        /// </summary>
        public int[] BuildPatternTable(string pattern)
        {
            if (pattern is null)
                throw new NullReferenceException(nameof(pattern));

            if (pattern == "")
                throw new ArgumentException($"{nameof(pattern)} cannot be an empty string");

            var table = new int[pattern.Length+1];
            table[0] = -1;

            int j = -1;
            int i = 0;

            while (i < pattern.Length)
            {
                while (j > -1 && pattern[i] != pattern[j])
                    j = table[j];
                i++;
                j++;

                if (i >= pattern.Length || j >= pattern.Length)
                {
                    table[i] = j;
                    break;
                }

                if (pattern[i] == pattern[j])
                    table[i] = table[j];
                else
                    table[i] = j;
            }

            lastPattern = pattern;
            lastTable = table;

            return table;
        }

        /// <summary>
        /// Finds the first occurance of the pattern in the supplied text
        /// </summary>
        /// <returns>The index if found or -1 if not found</returns>
        public int FindFirst(string text, string pattern, int startIndex = 0)
        {
            if (pattern is null || text is null)
                throw new NullReferenceException();

            int[] table;
            if (pattern != lastPattern)
                table = BuildPatternTable(pattern);
            else
                table = lastTable;

            int i = 0;

            for(int j = startIndex; j < text.Length; j++)
            {
                while (i > -1 && pattern[i] != text[j])
                    i = table[i];
                i++;
                if (i >= pattern.Length)
                    return j - i + 1;
            }

            return -1;
        }

        /// <summary>
        /// Finds all occurances of the pattern in the supplied text
        /// </summary>
        /// <returns>An enumerable of indices or an empty enumerable if not found</returns>
        public IEnumerable<int> FindAll(string text, string pattern, int startIndex = 0)
        {
            if (pattern is null || text is null)
                throw new NullReferenceException();

            int[] table;
            if (pattern != lastPattern)
                table = BuildPatternTable(pattern);
            else
                table = lastTable;

            int i = 0;

            for (int j = startIndex; j < text.Length; j++)
            {
                while (i > -1 && pattern[i] != text[j])
                    i = table[i];
                i++;
                if (i >= pattern.Length)
                {
                    yield return j - i + 1;
                    i = table[i];
                }
            }
        }
    }
}
