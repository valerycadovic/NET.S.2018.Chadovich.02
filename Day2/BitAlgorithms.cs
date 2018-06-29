namespace Day2
{
    using System;

    /// <summary>
    /// Contains a set of implementations of algorithms with bit operations
    /// </summary>
    public static class BitAlgorithms
    {
        /// <summary>
        /// Inserts preset count of bites from 32-bit number to another 32-bit number
        /// </summary>
        /// <param name="source">number to take bits from</param>
        /// <param name="drain">number to insert</param>
        /// <param name="start">start insert position</param>
        /// <param name="end">end insert position</param>
        /// <returns>mapped number</returns>
        public static int InsertNumber(int source, int drain, int start, int end)
        {
            if (source < 0 || drain < 0)
            {
                throw new ArgumentOutOfRangeException("numbers shouldn't be negative");
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException($"{nameof(start)} cannot be greater than {nameof(end)}");
            }

            if (start < 0 || start >= 32)
            {
                throw new ArgumentOutOfRangeException($"{nameof(start)} is out of range");
            }

            if (end < 0 || end >= 32)
            {
                throw new ArgumentOutOfRangeException($"{nameof(end)} is out of range");
            }

            source &= ~(int.MaxValue << (end - start + 1));
            source <<= start;
            return source | drain;
        }
    }
}
