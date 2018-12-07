using System;

namespace Monaco.Algorithms.Checksum
{
    /// <summary>
    /// Implementation of RFC1071's Internet Checksum which is a 16bit one's complement checksum.
    /// </summary>
    public class InternetChecksum
    {
        /// <summary>
        /// Makes an Internet Checksum from the supplied message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The checksum</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static ushort MakeChecksum(byte[] message)
        {
            if (message is null)
                throw new NullReferenceException();

            if (message.Length == 0)
                throw new ArgumentException($"{nameof(message)} was empty");

            int sum = 0;

            for(int i = 0; i < message.Length - 1; i += 2)
            {
                ushort pair = (ushort) ((message[i] << 8) + message[i + 1]);
                sum += pair;
            }

            if (message.Length % 2 != 0)
                sum += (message[message.Length - 1] << 8);

            while ((sum >> 16) > 0)
                sum = (sum & 0xFFFF) + (sum >> 16);

            return (ushort)~sum;
        }
    }
}
