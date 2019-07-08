using System;
using System.Linq;
using System.Collections.Generic;
using Monaco.Algorithms.Structures;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Structures
{
    [TestFixture]
    class PathTrieTests
    {
        [TestCaseSource(typeof(PathTrieTestCases), "AddCases")]
        public void Add_Items_AsExpected(IReadOnlyCollection<(string, int)> expectedItems)
        {
            var actualItems = new PathTrie<int>();

            foreach(var item in expectedItems)
                actualItems.Add(item.Item1, item.Item2);

            PathTrieAssert.EqualsAll(actualItems, expectedItems);
        }

        [TestCase("/Folder/UnparentedItem", 5)]
        public void Add_UnparentedItem_ThrowsKeyNotFoundException(string name, int value)
        {
            var trie = new PathTrie<int>();

            Assert.Throws<KeyNotFoundException>(() => trie.Add(name, value));
        }

        [TestCaseSource(typeof(PathTrieTestCases), "AddDuplicateCases")]
        public void Add_DuplicateItem_ThrowsArgumentException(IReadOnlyCollection<(string, int)> list,
            (string, int) duplicates)
        {
            var trie = new PathTrie<int>();

            foreach(var item in list)
                trie.Add(item.Item1, item.Item2);

            Assert.Throws<ArgumentException>(() => trie.Add(duplicates.Item1, duplicates.Item2));
        }

        [TestCaseSource(typeof(PathTrieTestCases), "PathKeyCases")]
        public void PathKey_ReturnsExpected(IReadOnlyCollection<(string, int)> items, string nodeKey, string expected)
        {
            var trie = new PathTrie<int>();

            foreach (var item in items)
                trie.Add(item.Item1, item.Item2);

            trie.TryGetNode(nodeKey, out var node);
            var actual = node.PathKey;

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(PathTrieTestCases), "EnumerateDepthFirstCases")]
        public void EnumerateDepthFirst_ReturnsExpected(IReadOnlyCollection<(string, int)> items,
            IReadOnlyCollection<IReadOnlyCollection<(string, int)>> expectedOrders)
        {
            var trie = new PathTrie<int>();

            foreach (var item in items)
                trie.Add(item.Item1, item.Item2);

            var trieDescendants = trie.EnumerateDepthFirst().Select(x => (x.PathKey, x.Value)).ToList();
            var listItems = items.ToList();

            ListAssert.EqualsAny(trieDescendants, expectedOrders);
        }
    }
}
