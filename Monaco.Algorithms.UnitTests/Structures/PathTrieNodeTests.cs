using System.Linq;
using System.Collections.Generic;
using Monaco.Algorithms.Structures;
using NUnit.Framework;
using Monaco.Algorithms.UnitTests.AssertHelpers;

namespace Monaco.Algorithms.UnitTests.Structures
{
    [TestFixture]
    class PathTrieNodeTests
    {
        private IPathTrieNode<int> parent;
        private readonly (string, int)[] nodeChildren = new (string, int)[]
        {
            ("SubItem1", 1), ("SubItem2", 2), ("SubItem3", 3)
        };

        [SetUp]
        public void Setup()
        {
            parent = new PathTrieNode<int>("parent", -1);
            foreach (var item in nodeChildren)
                parent.AddChild(item.Item1, item.Item2);
        }

        [TestCase("TestItem1", 15)]
        public void AddChild_AsExpected(string name, int value)
        {
            parent.AddChild(name, value);

            parent.TryGetChild(name, out var node);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(name, node.Name);
                Assert.AreEqual(value, node.Value);
            });
        }

        [TestCase("SubItem2")]
        public void RemoveChild_AsExpected(string name)
        {
            parent.RemoveChild(name);
            Assert.IsFalse(parent.ContainsChild(name));
        }

        [TestCase("SubItem1")]
        [TestCase("SubItem2")]
        [TestCase("SubItem3")]
        public void ContainsChild_Found_AsExpected(string name)
        {
            Assert.IsTrue(parent.ContainsChild(name));
        }

        [TestCase("SubItem18")]
        [TestCase("subitem1")]
        public void ContainsChild_NotFound_AsExpected(string name)
        {
            Assert.IsFalse(parent.ContainsChild(name));
        }

        [TestCase("SubItem2", 2)]
        public void TryGetChild_ReturnsExpected(string name, int expectedValue)
        {
            var isFound = parent.TryGetChild(name, out var node);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isFound);
                Assert.NotNull(node);
                Assert.AreEqual(name, node.Name);
                Assert.AreEqual(expectedValue, node.Value);
            });
        }

        [Test]
        public void Children_ReturnsExpected()
        {
            var actual = parent.Children().Select(x => (x.Name, x.Value)).ToList();
            ListAssert.ContainsSameItems(nodeChildren, actual);
        }
    }
}
