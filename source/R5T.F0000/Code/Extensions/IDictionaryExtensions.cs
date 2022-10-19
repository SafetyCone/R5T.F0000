using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class IDictionaryExtensions
    {
        public static TValue AcquireValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueConstructor)
        {
            var output = Instances.DictionaryOperator.AcquireValue(dictionary, key, valueConstructor);
            return output;
        }

        public static TValue AddAndReturnValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            var output = Instances.DictionaryOperator.AddAndReturnValue(dictionary, key, value);
            return output;
        }

        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> values)
        {
            Instances.DictionaryOperator.AddRange(dictionary, values);
        }
    }
}
