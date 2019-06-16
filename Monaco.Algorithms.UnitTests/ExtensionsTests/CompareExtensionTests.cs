using NUnit.Framework;
using Monaco.Algorithms.Extensions;

namespace Monaco.Algorithms.UnitTests.ExtensionsTests
{
    [TestFixture]
    class CompareExtensionTests
    {
        [TestCase(9, 10, 15)]
        [TestCase(0, 10, 15)]
        [TestCase(-11, -10, -2)]
        public void Clamp_BelowRange_ReturnsMinimum(int value, int min, int max)
        {
            var actual = value.Clamp(min, max);
            Assert.AreEqual(min, actual);
        }

        [TestCase(10, 10, 15)]
        [TestCase(12, 10, 15)]
        [TestCase(15, 10, 15)]
        public void Clamp_InRange_ReturnsValue(int value, int min, int max)
        {
            var actual = value.Clamp(min, max);
            Assert.AreEqual(value, actual);
        }

        [TestCase(16, 10, 15)]
        [TestCase(2500, 10, 15)]
        [TestCase(-1, -10, -2)]
        public void Clamp_AboveRange_ReturnsMaximum(int value, int min, int max)
        {
            var actual = value.Clamp(min, max);
            Assert.AreEqual(max, actual);
        }

        [Test]
        public void EqualsAny_ReturnsExpected()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(10.EqualsAny(10));
                Assert.IsTrue(10.EqualsAny(15, 10));
                Assert.IsTrue(10.EqualsAny(15, 30, 10, 50, 90, 100));
                Assert.IsFalse(10.EqualsAny(15));
                Assert.IsFalse(10.EqualsAny(15, 20));
                Assert.IsFalse(10.EqualsAny(15, 30, 50, 90, 100));
            });
        }
    }
}
