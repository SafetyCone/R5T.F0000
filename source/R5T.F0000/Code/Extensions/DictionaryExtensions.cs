using System;
using System.Collections.Generic;

using R5T.L0089.T000;

using Instances = R5T.F0000.Instances;


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

        public static TValue AddAndReturnValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            return Instances.DictionaryOperator.AddAndReturn_Value(
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
