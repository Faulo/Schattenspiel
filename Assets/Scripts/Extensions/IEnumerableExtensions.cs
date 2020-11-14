using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions {
    public static class IEnumerableExtensions {
        public static void ForAll<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T item in source) {
                action(item);
            }
        }
        public static IEnumerable<T> Log<T>(this IEnumerable<T> source) {
            foreach (T item in source) {
                Debug.Log(item);
            }
            return source;
        }
        //https://stackoverflow.com/questions/8741439/what-is-the-opposite-method-of-anyt
            public static bool None<TSource>(this IEnumerable<TSource> source) {
            return !source.Any();
        }
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            return !source.Any(predicate);
        }
    }
}
