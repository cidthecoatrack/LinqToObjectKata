using System;
using System.Collections.Generic;

namespace LinqToObjectKata
{
    public static class Bucket
    {
        public static Int32 Count<T>(this IEnumerable<T> source)
        {
            var count = 0;

            foreach (T e in source)
                count++;

            return count;
        }

        public static Int32 Count<T>(this IEnumerable<T> source, Func<T, Boolean> function)
        {
            var count = 0;

            foreach (T e in source)
                if (function(e))
                    count++;

            return count;
        }

        public static Boolean Any<T>(this IEnumerable<T> source)
        {
            foreach (T e in source)
                return true;

            return false;
        }

        public static Boolean Any<T>(this IEnumerable<T> source, Func<T, Boolean> function)
        {
            foreach (T e in source)
                if (function(e))
                    return true;

            return false;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            var matched = new HashSet<T>();

            foreach (T e in source)
            {
                if (!matched.Contains(e))
                {
                    matched.Add(e);
                    yield return e;
                }
            }
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            var matched = new HashSet<T>(comparer);

            foreach (T e in source)
            {
                if (!matched.Contains(e))
                {
                    matched.Add(e);
                    yield return e;
                }
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, Boolean> function)
        {
            foreach (T e in source)
                if (function(e))
                    yield return e;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, Int32, Boolean> function)
        {
            var index = 0;

            foreach (T e in source)
                if (function(e, index++))
                    yield return e;
        }

        public static T First<T>(this IEnumerable<T> source)
        {
            foreach (T e in source)
                return e;

            throw new InvalidOperationException();
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, Boolean> function)
        {
            foreach (T e in source)
                if (function(e))
                    return e;

            throw new InvalidOperationException();
        }

        public static T Last<T>(this IEnumerable<T> source)
        {
            T lastItem = source.First();

            foreach (T e in source)
                lastItem = e;

            return lastItem;
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, Boolean> function)
        {
            T lastItem = source.First();

            foreach (T e in source)
                if (function(e))
                    lastItem = e;

            return lastItem;
        }
    }
}
