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
            Instances.DictionaryOperator.Add_OrReplace(dictionary, key, value);
        }

        public static void AddValue<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
        {
            Instances.DictionaryOperator.AddValue(
                dictionary,
                key,
                value);
        }

        public static WasFound<TValue> HasValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return Instances.DictionaryOperator.HasValue(
                dictionary,
                key);
        }
    }
}
