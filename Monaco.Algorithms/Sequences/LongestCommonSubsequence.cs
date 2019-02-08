using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Sequences
{
    public static class LongestCommonSubsequence
    {
        /// <summary>
        /// Returns the LCS length using a slow, recursive method
        /// O(2^(m+n)) runtime complexity
        /// </summary>
        public static int LcsLengthRecursive(string s1, string s2)
        {
            if (s1 is null || s2 is null)
                throw new NullReferenceException();

            return LocalLcsLengthRecursive(s1, s2, s1.Length, s2.Length);

            int LocalLcsLengthRecursive(string p, string q, int m, int n)
            {
                if (m == 0 || n == 0)
                    return 0;
                else if (s1[m - 1] == s2[n - 1])
                    return 1 + LocalLcsLengthRecursive(s1, s2, m - 1, n - 1);
                else
                {
                    var result1 = LocalLcsLengthRecursive(p, q, m - 1, n);
                    var result2 = LocalLcsLengthRecursive(p, q, m, n - 1);
                    return Max(result1, result2);
                }
            }
        }

        /// <summary>
        /// Returns the LCS length using a recursive, top-down memoization method
        /// O(m*n) runtime complexity
        /// O(m*n) memory complexity
        /// </summary>
        public static int LcsLengthMemo(string s1, string s2)
        {
            if (s1 is null || s2 is null)
                throw new NullReferenceException();

            if (s1.Length == 0 || s2.Length == 0)
                return 0;

            var memo = new int[s1.Length, s2.Length];
            for(int i = 0; i < s1.Length; i++)
                for(int j = 0; j < s2.Length; j++)
                    memo[i, j] = -1;

            var res = LocalLcsLengthMemo(s1, s2, s1.Length - 1, s2.Length - 1);

            return res;

            int LocalLcsLengthMemo(string p, string q, int m, int n)
            {
                if (m < 0 || n < 0)
                    return 0;

                if (memo[m, n] != -1)
                    return memo[m, n];

                int result;
                if (s1[m] == s2[n])
                    result = 1 + LocalLcsLengthMemo(s1, s2, m - 1, n - 1);
                else
                {
                    var result1 = LocalLcsLengthMemo(p, q, m - 1, n);
                    var result2 = LocalLcsLengthMemo(p, q, m, n - 1);
                    result = Max(result1, result2);
                }

                memo[m, n] = result;
                return result;
            }
        }

        /// <summary>
        /// Returns the LCS table using a bottom-up dynamic programming method
        /// O(m*n) runtime complexity
        /// O(m*n) memory complexity
        /// </summary>
        private static int[,] LcsDynamic(string s1, string s2)
        {
            var table = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        table[i, j] = 1 + table[i - 1, j - 1];
                    else
                        table[i, j] = Max(table[i - 1, j], table[i, j - 1]);
                }
            }

            return table;
        }

        /// <summary>
        /// Returns the LCS length using a bottom-up dynamic programming method
        /// </summary>
        public static int LcsLengthDynamic(string s1, string s2)
        {
            if (s1 is null || s2 is null)
                throw new NullReferenceException();

            if (s1.Length == 0 || s2.Length == 0)
                return 0;

            var table = LcsDynamic(s1, s2);

            return table[table.GetUpperBound(0), table.GetUpperBound(1)];
        }

        /// <summary>
        /// Returns the LCS string using a bottom-up dynamic programming method
        /// </summary>
        public static string LcsStringDynamic(string s1, string s2)
        {
            if (s1 is null || s2 is null)
                throw new NullReferenceException();

            if (s1.Length == 0 || s2.Length == 0)
                return "";

            var table = LcsDynamic(s1, s2);

            int i = table.GetUpperBound(0);
            int j = table.GetUpperBound(1);

            var len = table[i, j];

            if (len == 0)
                return "";

            var result = new char[len];
            var resultIndex = len - 1;

            while(i > 0 && j > 0)
            {
                if(s1[i-1] == s2[j-1])
                {
                    result[resultIndex] = s1[i-1];
                    resultIndex--;
                    i--;
                    j--;
                }
                else if(table[i-1, j] > table[i, j-1])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            return new string(result);
        }

        private static int Max(int a, int b) => (a >= b) ? a : b;
    }
}
