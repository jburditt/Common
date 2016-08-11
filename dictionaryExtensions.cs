using System.Collections.Generic;

namespace Common
{
    public static class DictionaryExtensions
    {
        public static string GetString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return value == null ? null : value.ToString();
        }

        public static int GetInt<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            var value = dictionary.GetString(key);
            int returnValue;
            int.TryParse(value, out returnValue);
            return returnValue;
        }
    }
}
