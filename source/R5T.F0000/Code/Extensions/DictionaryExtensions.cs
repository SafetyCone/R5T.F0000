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
    }
}
