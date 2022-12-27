using System;
using System.Collections.Generic;

using R5T.F0000;


namespace System.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddOrReplaceValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            DictionaryOperator.Instance.AddOrReplaceValue(dictionary, key, value);
        }

        public static WasFound<TValue> HasValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            var containsKey = dictionary.ContainsKey(key);

            var value = containsKey
                ? dictionary[key]
                : default
                ;

            var output = WasFound.From(containsKey, value);
            return output;
        }
    }
}
