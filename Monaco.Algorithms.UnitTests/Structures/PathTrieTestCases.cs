using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace Monaco.Algorithms.UnitTests.Structures
{
    public class PathTrieTestCases
    {
        public static IEnumerable<TestCaseData> AddCases()
        {
            var singleItemList = new List<(string, int)> { ("/Folder1", 1) };
            yield return new TestCaseData(singleItemList);

            var nestedList = new List<(string, int)> {
                ("/Folder1", 1),
                ("/Folder1/Item1", 15),
                ("/Folder1/Item2", 25),
                ("/Folder2", 2),
                ("/Folder2/Folder3", 3),
                ("/Folder2/Folder3/Item3", 5)
            };
            yield return new TestCaseData(nestedList);
        }

        public static IEnumerable<TestCaseData> AddDuplicateCases()
        {
            var items = new List<(string, int)> { ("/Folder1", 1), ("/Folder1/Item1", 15) };
            var rootDuplicate = ("/Folder1", 1);

            yield return new TestCaseData(items, rootDuplicate);

            var childDuplicate = ("/Folder1/Item1", 15);

            yield return new TestCaseData(items, childDuplicate);
        }

        public static IEnumerable<TestCaseData> EnumerateDepthFirstCases()
        {
            var singleItemList = new List<(string, int)> { ("/Folder1", 0) };
            yield return new TestCaseData(singleItemList.AsReadOnly(), new List<List<(string, int)>> { singleItemList }.AsReadOnly());

            var nestedList = new List<(string, int)> {
                ("/Folder1", 1),
                ("/Folder1/Folder2", 2),
                ("/Folder1/Folder2/Item3", 5),
            };
            yield return new TestCaseData(nestedList.AsReadOnly(), new List<List<(string, int)>> { nestedList }.AsReadOnly());

            var manyItemList = new List<(string, int)> {
                ("/Folder2", 22),
                ("/Folder2/ItemA", 17),
                ("/Folder1", 11),
                ("/Folder1/Folder3", 3),
                ("/Folder1/Folder3/Item3", 35)
            };

            var manyItemListOrders = new List<List<(string, int)>>
            {
                new List<(string, int)>
                {
                    ("/Folder2", 22),
                    ("/Folder2/ItemA", 17),
                    ("/Folder1", 11),
                    ("/Folder1/Folder3", 3),
                    ("/Folder1/Folder3/Item3", 35)
                },
                new List<(string, int)>
                {
                    ("/Folder1", 11),
                    ("/Folder1/Folder3", 3),
                    ("/Folder1/Folder3/Item3", 35),
                    ("/Folder2", 22),
                    ("/Folder2/ItemA", 17),
                }

            };
            yield return new TestCaseData(manyItemList.AsReadOnly(), manyItemListOrders.AsReadOnly());
        }

        public static IEnumerable<TestCaseData> PathKeyCases()
        {
            var manyItemList = new List<(string, int)> {
                ("/Folder1", 1),
                ("/Folder1/Folder3", 3),
                ("/Folder1/Folder3/Item3", 5),
                ("/Folder1/Item1", 15),
                ("/Folder1/Item2", 25),
                ("/Folder2", 2)
            }.AsReadOnly();

            yield return new TestCaseData(manyItemList, "/Folder1", "/Folder1");
            yield return new TestCaseData(manyItemList, "/Folder1/Folder3/", "/Folder1/Folder3");
            yield return new TestCaseData(manyItemList, "/Folder1/Folder3/Item3", "/Folder1/Folder3/Item3");
        }
    }
}
