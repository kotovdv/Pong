using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            TValue value;

            return dictionary.TryGetValue(key, out value)
                ? value
                : defaultValue;
        }

        public static void ForEach<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            Action<TKey, TValue> action)
        {
            foreach (var pair in dictionary)
                action(pair.Key, pair.Value);
        }
    }
}