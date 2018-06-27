namespace Day2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods set of collections
    /// </summary>
    public static class CollectionHelper
    {
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

            foreach (var item in collection)
            {
                if (match(item))
                {
                    yield return item;
                }
            }
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

            if (!char.TryParse(digit.ToString(), out char charDigit))
            {
                throw new InvalidOperationException(nameof(digit) + " must be digit");
            }

            List<int> result = new List<int>();

            foreach (var item in array)
            {
                if (item.ToString().Contains(digit.ToString()))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
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
    }
}
