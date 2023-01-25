using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDictionaryOperator : IFunctionalityMarker
	{
        public TValue AcquireValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueConstructor)
        {
            if (dictionary.ContainsKey(key))
            {
                var value = dictionary[key];
                return value;
            }
            else
            {
                var value = valueConstructor();

                return dictionary.AddAndReturnValue(key, value);
            }
        }

        public TValue AddAndReturnValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            dictionary.Add(key, value);

            return value;
        }

        public void AddOrReplaceValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            var hasKey = dictionary.ContainsKey(key);
            if(hasKey)
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public void AddRange<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> values)
        {
            foreach (var pair in values)
            {
                dictionary.Add(pair);
            }
        }

        public bool EqualCounts<TKey, TValue>(
            IDictionary<TKey, TValue> a,
            IDictionary<TKey, TValue> b)
        {
            var countsAreEqual = a.Count == b.Count;
            return countsAreEqual;
        }

        public KeyNotFoundException GetKeyNotFoundException(string key)
        {
            var message = this.GetKeyNotFoundExceptionMessage(key);

            var exception = new KeyNotFoundException(message);
            return exception;
        }

        public string GetKeyNotFoundExceptionMessage(string key)
        {
            var message = $"Key not found: '{key}'";
            return message;
        }

        public bool IsEmpty<TKey, TValue>(IDictionary<TKey, TValue> pairs)
        {
            var output = pairs.Count == 0;
            return output;
        }

        public string[] OutputToLines<TValue>(IEnumerable<KeyValuePair<string, TValue>> stringsByString)
            where TValue : IEnumerable<string>
        {
            var output = stringsByString
                .SelectMany(pair => EnumerableOperator.Instance.From(pair.Key)
                    .AppendRange(pair.Value
                        .Select(x => $"\t{x}")))
                .Now();

            return output;
        }

        public string OutputToText<TValue>(IEnumerable<KeyValuePair<string, TValue>> stringsByString)
            where TValue : IEnumerable<string>
        {
            var lines = this.OutputToLines(stringsByString);

            var text = TextOperator.Instance.JoinLines(lines);
            return text;
        }

        public void VerifyEqualCounts<TKey, TValue>(
            IDictionary<TKey, TValue> a,
            IDictionary<TKey, TValue> b)
        {
            var countsAreEqual = this.EqualCounts(a, b);
            if (!countsAreEqual)
            {
                throw ExceptionOperator.Instance.GetDictionaryCountsUnequalException(a, b);
            }
        }
    }
}