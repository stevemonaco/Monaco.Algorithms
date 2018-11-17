using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.AssertHelpers
{
    static class SortAssert
    {
        public static void IsSortedAscending<T>(IEnumerable<T> items, IComparer<T> comparer) where T : IComparable<T>
        {
            var prev = items.FirstOrDefault();

            foreach(var item in items)
            {
                if(prev.CompareTo(item) > 0)
                    Assert.Fail($"item {prev} was found before item {item}");
                prev = item;
            }
        }

        public static void IsSortedDescending<T>(IEnumerable<T> items, IComparer<T> comparer) where T : IComparable<T>
        {
            var prev = items.FirstOrDefault();

            foreach (var item in items)
            {
                if (prev.CompareTo(item) < 0)
                    Assert.Fail($"item {prev} was found after item {item}");
                prev = item;
            }
        }
    }
}
