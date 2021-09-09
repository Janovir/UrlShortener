using System.Collections.Generic;

namespace Services
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Extension method to swap keys and values in a dictionary
        /// </summary>
        /// <returns>Reversed Dictionary</returns>
        public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var dictionary = new Dictionary<TValue, TKey>();

            foreach (var entry in source)
            {
                if (!dictionary.ContainsKey(entry.Value))
                    dictionary.Add(entry.Value, entry.Key);
            }

            return dictionary;
        }
    }
}
