using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Monaco.Algorithms.Checksum;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Checksum
{
    [TestFixture]
    public class InternetChecksumTests
    {
        [TestCase(new byte[] { 0xFF }, (ushort)0x00FF)]
        [TestCase(new byte[] { 0x00, 0x01, 0xF2, 0x03, 0xF4, 0xF5, 0xF6, 0xF7 }, (ushort)0x220D) ]
        [TestCase(new byte[] { 0xe3, 0x4f, 0x23, 0x96, 0x44, 0x27, 0x99, 0xf3 }, (ushort)0x1AFF)]
        public void MakeChecksum_ValidMessage_MakesCorrectly(byte[] message, ushort expectedChecksum)
        {
            var actualChecksum = InternetChecksum.MakeChecksum(message);

            Assert.AreEqual(expectedChecksum, actualChecksum, $"Expected {expectedChecksum:X} Actual {actualChecksum:X}");
        }

        [TestCase(new byte[] { })]
        public void MakeChecksum_EmptyMessage_ThrowsArgumentException(byte[] message)
        {
            Assert.Throws<ArgumentException>(() => InternetChecksum.MakeChecksum(message));
        }

        [TestCase(null)]
        public void MakeChecksum_NullMessage_ThrowsNullReferenceException(byte[] message)
        {
            Assert.Throws<NullReferenceException>(() => InternetChecksum.MakeChecksum(message));
        }
    }
}
