using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Extensions
{
    /// <summary>
    /// Extensions for Dictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Extension method to swap keys and values in a dictionary
        /// </summary>
        /// <returns>Reversed Dictionary</returns>
        public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source) => source.ToDictionary(x => x.Value, y => y.Key);
    }
}
