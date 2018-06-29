namespace Day2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods set for collections
    /// </summary>
    public static class CollectionHelper
    {
        #region Task 6 via delegates
        /// <summary>
        /// Filters collection according to preset predicate
        /// </summary>
        /// <typeparam name="T">type of collection elements</typeparam>
        /// <param name="collection">collection to be extended</param>
        /// <param name="match">matching condition</param>
        /// <returns>Collection of matched elements</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> match)
        {
            ValidateIsNull(collection, nameof(collection));
            ValidateIsNull(match, nameof(match));

            IEnumerable<T> InnerYield()                 // to handle exceptions in deferred execution method
            {
                foreach (var item in collection)
                {
                    if (match(item))
                    {
                        yield return item;
                    }
                }
            }

            return InnerYield();
        }
        #endregion

        #region Task 6
        /// <summary>
        /// Filters array of parameters by containing preset number in element
        /// </summary>
        /// <param name="digit">array to extend</param>
        /// <param name="array">digit to search</param>
        /// <returns>Array of matched elements</returns>
        public static int[] FilterDigit(int digit, params int[] array)
        {
            return array.FilterDigit(digit);
        }

        /// <summary>
        /// Filters array with integer numbers by containing preset number in element
        /// </summary>
        /// <param name="array">array to extend</param>
        /// <param name="digit">digit to search</param>
        /// <returns>Array of matched elements</returns>
        public static int[] FilterDigit(this int[] array, int digit)
        {
            ValidateIsNull(array, nameof(array));
            ValidateDigit(digit);

            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().Contains(digit.ToString()))
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }
        #endregion

        /// <summary>
        /// Filters array with integer numbers by containing preset number in element via arithmetic operations
        /// </summary>
        /// <param name="digit">digit to search</param>
        /// <param name="array">array to extend</param>
        /// <returns>Array of matched elements</returns>
        public static int[] FilterDigitViaDivision(int digit, params int[] array)
        {
            ValidateDigit(digit);

            List<int> result = new List<int>();

            int item = 0;
            for (int i = 0; i < array.Length; i++)
            {
                item = array[i];

                while (item != 0)
                {
                    if (digit == Math.Abs(item % 10))
                    {
                        result.Add(array[i]);
                        break;
                    }

                    item /= 10;
                }
            }

            return result.ToArray();
        }

        #region Private Validation Methods
        /// <summary>
        /// checks if it is a digit
        /// </summary>
        /// <param name="digit">digit to check</param>
        private static void ValidateDigit(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit) + " must be digit");
            }
        }

        /// <summary>
        /// Checks if object is null
        /// </summary>
        /// <param name="object">reference to check</param>
        /// <param name="objName">name of object</param>
        private static void ValidateIsNull(object @object, string objName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(objName + " refers to null");
            }
        }
        #endregion
    }
}
