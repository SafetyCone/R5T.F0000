using System;
using System.Collections.Generic;

using Instances = R5T.F0000.Instances;


namespace System
{
    public static class IDictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> values)
        {
            Instances.DictionaryOperator.AddRange(dictionary, values);
        }
    }
}
