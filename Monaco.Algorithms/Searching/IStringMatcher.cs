using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Searching
{
    public interface IStringMatcher
    {
        int FindFirst(string text, string pattern, int startIndex = 0);
        IEnumerable<int> FindAll(string text, string pattern, int startIndex = 0);
    }
}
