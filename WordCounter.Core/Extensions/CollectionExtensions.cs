using System;
using System.Collections.Generic;

namespace WordCounter.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static SortedDictionary<T1, T2> ToSortedDictionary<T1, T2>(this Dictionary<T1, T2> data, bool asc = true)
            where T1 : IComparable
        {
            return asc == false
                ? new SortedDictionary<T1, T2>(data, Comparer<T1>.Create((x, y) => y.CompareTo(x)))
                : new SortedDictionary<T1, T2>(data);
        }
    }
}
