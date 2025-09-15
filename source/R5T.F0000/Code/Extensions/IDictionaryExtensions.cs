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
            var output = Instances.DictionaryOperator.Acquire_Value(dictionary, key, valueConstructor);
            return output;
        }

        public static TValue AddAndReturnValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            var output = Instances.DictionaryOperator.AddAndReturn_Value(dictionary, key, value);
            return output;
        }

        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> values)
        {
            Instances.DictionaryOperator.AddRange(dictionary, values);
        }
    }
}


namespace R5T.F0000.Extensions
{
    public static class IDictionaryExtensions
    {
        /// <inheritdoc cref="L0066.IDictionaryOperator.Add_Value{TKey, TValue}(IDictionary{TKey, List{TValue}}, TKey, TValue)"/>
        public static void Add_Value<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
        {
            Instances.DictionaryOperator.Add_Value(
                dictionary,
                key,
                value);
        }

        /// <inheritdoc cref="IDictionaryOperator.Add_IfKeyNotFound{TKey, TValue}(IDictionary{TKey, TValue}, TKey, TValue)"/>
        public static void Add_IfKeyNotFound<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            Instances.DictionaryOperator.Add_IfKeyNotFound(
                dictionary,
                key,
                value);
        }

        /// <inheritdoc cref="F10Y.L0000.IDictionaryOperator.Add_OrReplace{TKey, TValue}(IDictionary{TKey, TValue}, TKey, TValue)"/>
        public static void Add_OrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            Instances.DictionaryOperator.Add_OrReplace(
                dictionary,
                key,
                value);
        }
    }
}
