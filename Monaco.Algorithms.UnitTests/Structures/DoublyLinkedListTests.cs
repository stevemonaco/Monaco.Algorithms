using System;
using System.Collections.Generic;
using System.Linq;
using Monaco.Algorithms.Structures;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Structures
{
    [TestFixture]
    class DoublyLinkedListTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 5 })]
        [TestCase(new int[] { 5, 8 })]
        [TestCase(new int[] { 5, 8, 1, 15, 20, 80, 51 })]
        public void Add_Correctly(IEnumerable<int> expected)
        {
            var actual = new DoublyLinkedList<int>();

            foreach (var item in expected)
                actual.Add(item);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 5 })]
        [TestCase(new int[] { 5, 8 })]
        [TestCase(new int[] { 5, 8, 1, 15, 20, 80, 51 })]
        public void AddFront_Correctly(IEnumerable<int> items)
        {
            var expected = items.Reverse().ToArray();
            var actual = new DoublyLinkedList<int>();

            foreach (var item in items)
                actual.AddFront(item);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5 })]
        [TestCase(new int[] { 15, 8, 1, 15, 20, 80, 51 })]
        public void PopFront_ReturnsExpected(int[] items)
        {
            var expected = items[0];
            var list = new DoublyLinkedList<int>(items);

            var actual = list.PopFront();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 20 })]
        [TestCase(new int[] { 20, 25 })]
        [TestCase(new int[] { 15, 8, 1, 15, 20, 80, 51 })]
        public void PopFront_EmptyList_ThrowsInvalidOperationException(int[] items)
        {
            var list = new DoublyLinkedList<int>(items);

            while (list.Count > 0)
                list.PopFront();

            Assert.Throws<InvalidOperationException>(() => { list.PopFront(); });
        }

        [TestCase(new int[] { 5 })]
        [TestCase(new int[] { 15, 8, 1, 15, 20, 80, 51 })]
        public void PopBack_ReturnsExpected(int[] items)
        {
            var expected = items[items.GetUpperBound(0)];
            var list = new DoublyLinkedList<int>(items);

            var actual = list.PopBack();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 20 })]
        [TestCase(new int[] { 20, 25 })]
        [TestCase(new int[] { 15, 8, 1, 15, 20, 80, 51 })]
        public void PopBack_EmptyList_ThrowsInvalidOperationException(int[] items)
        {
            var list = new DoublyLinkedList<int>(items);

            while (list.Count > 0)
                list.PopBack();

            Assert.Throws<InvalidOperationException>(() => { list.PopBack(); });
        }

        [TestCase(new int[] { 5 }, 0)]
        [TestCase(new int[] { 5, 8 }, 0)]
        [TestCase(new int[] { 5, 8 }, 1)]
        [TestCase(new int[] { 5, 8, 1, 15, 20, 80, 51 }, 4)]
        public void Remove_ByNode_Correctly(IEnumerable<int> items, int removeIndex)
        {
            var expected = items.ToList();
            var actual = new DoublyLinkedList<int>(expected);

            expected.RemoveAt(removeIndex);
            var node = actual[removeIndex];
            actual.Remove(node);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5 }, 0, 5)]
        [TestCase(new int[] { 5, 8 }, 0, 5)]
        [TestCase(new int[] { 5, 8 }, 1, 8)]
        [TestCase(new int[] { 5, 8, 1, 15, 20, 80, 51 }, 4, 20)]
        public void Indexer_ValidIndex_ReturnsNode(IEnumerable<int> items, int index, int expected)
        {
            var actualList = new DoublyLinkedList<int>(items);
            var actual = actualList[index].Value;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 5 }, -1)]
        [TestCase(new int[] { 5, 8 }, 2)]
        [TestCase(new int[] { }, 0)]
        public void Indexer_InvalidIndex_ThrowsIndexOutOfRangeException(IEnumerable<int> items, int index)
        {
            var actual = new DoublyLinkedList<int>(items);

            Assert.Throws<IndexOutOfRangeException>(() => { var t = actual[index]; });
        }
    }
}
