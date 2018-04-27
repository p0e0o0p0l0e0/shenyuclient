using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public static class Linq
    {
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source is IList<TSource>)
            {
                return (source as IList<TSource>)[index];
            }
            if (source is IList)
            {
                return (TSource)(source as IList)[index];
            }
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
            TAG:
                if (enumerator.MoveNext())
                {
                    if (index == 0)
                        return enumerator.Current;
                    else
                        index -= 1;
                    goto TAG;
                }
                throw new ArgumentOutOfRangeException("index");
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");


            List<TSource> list = new List<TSource>();
            foreach (var each in source)
            {
                if (predicate(each))
                {
                    list.Add(each);
                }
            }
            return list;
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            IList<TSource> list = source as IList<TSource>;
            if (list != null && list.Count > 0)
                return list[list.Count - 1];
            using (IEnumerator<TSource> ie = source.GetEnumerator())
            {
                if (ie.MoveNext())
                {
                    TSource current;
                    do
                    {
                        current = ie.Current;
                    } while (ie.MoveNext());
                    return current;
                }
            }
            return default(TSource);
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source is IList<TSource>)
            {
                var list = source as IList<TSource>;
                if (list.Count > 0)
                    return list[0];
                throw new Exception("is empty");
            }
            if (source is IList)
            {
                var list = source as IList;
                if (list.Count > 0)
                    return (TSource)list[0];
                throw new Exception("is empty");
            }

            using (IEnumerator<TSource> ie = source.GetEnumerator())
            {
                if (ie.MoveNext())
                    return ie.Current;
            }

            throw new Exception("is empty");
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            using (IEnumerator<TSource> ie = source.GetEnumerator())
            {
                while (ie.MoveNext())
                {
                    if (predicate(ie.Current))
                        return ie.Current;
                }
            }
            return default(TSource);
        }

        /// <summary>
        /// 深度分组排序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, params OrderByComparer<TSource>[] comp)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            List<TSource> list = new List<TSource>();
            list.AddRange(source);

            if (comp.Length > 0)
                OrderBy(list, 0, list.Count, 0, comp);

            return list;
        }

        public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, int start, int count, params OrderByComparer<TSource>[] comp)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (count < 0)
                throw new IndexOutOfRangeException("count");

            List<TSource> list = new List<TSource>();
            list.AddRange(source);

            if (start < 0 || start >= list.Count)
                throw new IndexOutOfRangeException("start");
            if (start + count < 0 || start + count >= list.Count)
                throw new IndexOutOfRangeException("count");

            if (comp.Length > 0)
                OrderBy(list, start, count, 0, comp);

            return list;
        }


        private static void OrderBy<TSource>(List<TSource> source, int start, int count, int layer, OrderByComparer<TSource>[] sorters)
        {
            if (count < 1)
                return;
            if (layer >= sorters.Length)
                return;

            var sort = sorters[layer++];
            source.Sort(start, count, sort);

            //sort next layer
            if (count > 1 && layer < sorters.Length)
            {
                //var nextsort = sorters[layer];
                int s = start, c = 1;
                TSource pre = source[start], cur;
                for (int i = start + 1; i < count; ++i)
                {
                    cur = source[i];
                    if (sort.Compare(pre, cur) == 0)
                    {
                        c += 1;
                    }
                    else
                    {
                        if (c > 1)
                        {
                            OrderBy(source, s, c, layer, sorters);
                        }
                        s = i;
                        c = 1;
                    }
                    pre = cur;
                }
                if (c > 1)
                    OrderBy(source, s, c, layer, sorters);
            }
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            TSource[] array = new TSource[source.Count()];
            using (var ie = source.GetEnumerator())
            {
                int index = 0;
                TAG:
                if (ie.MoveNext())
                {
                    array[index++] = ie.Current;
                    goto TAG;
                }
            }
            return array;
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            List<TSource> list = new List<TSource>();
            list.AddRange(source);
            return list;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (source is ICollection<TSource>)
            {
                return (source as ICollection<TSource>).Count;
            }
            if (source is ICollection)
            {
                return (source as ICollection).Count;
            }
            int count = 0;
            using (var ie = source.GetEnumerator())
            {
            TAG:
                if (ie.MoveNext())
                {
                    count += 1;
                    goto TAG;
                }
                return count;
            }
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Where(predicate).Count();
        }

        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            List<TSource> list = new List<TSource>();
            if (count < 1)
            {
                list.AddRange(source);
                return list;
            }
            if (source.Count() <= count)
                return list;

            using (var ie = source.GetEnumerator())
            {
            TAG:
                if (ie.MoveNext())
                {
                    if (count < 1)
                        list.Add(ie.Current);
                    else
                        count -= 1;
                    goto TAG;
                }
                return list;
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            List<TSource> list = new List<TSource>();
            if (count < 1)
                return list;
            if (source.Count() <= count)
            {
                list.AddRange(source);
                return list;
            }

            using (var ie = source.GetEnumerator())
            {
            TAG:
                if (ie.MoveNext())
                {
                    if (count > 0)
                        list.Add(ie.Current);
                    else
                        return list;
                    count -= 1;
                    goto TAG;
                }
                return list;
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            using (var ie = source.GetEnumerator())
            {
                List<TResult> list = new List<TResult>();
            TAG:
                if (ie.MoveNext())
                {
                    list.Add(selector(ie.Current));
                    goto TAG;
                }

                return list;
            }
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (other == null)
                throw new ArgumentNullException("other");

            HashSet<TSource> set = new HashSet<TSource>(source);
            {
                foreach (var each in other)
                    if (set.Contains(each))
                        set.Remove(each);

                List<TSource> list = new List<TSource>();
                foreach (var each in source)
                    if (set.Contains(each))
                        list.Add(each);

                return list;
            }
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (other == null)
                throw new ArgumentNullException("other");

            HashSet<TSource> set = new HashSet<TSource>(source, comparer);
            {
                foreach (var each in other)
                    if (set.Contains(each))
                        set.Remove(each);

                List<TSource> list = new List<TSource>();
                foreach (var each in source)
                    if (set.Contains(each))
                        list.Add(each);

                return list;
            }
        }

        public static byte Min(this IEnumerable<byte> source)
        {
            return Min(source, (a) => { return a; }, ByteComparer.Default);
        }
        public static int Min(this IEnumerable<int> source)
        {
            return Min(source, (a) => { return a; }, IntComparer.Default);
        }
        public static long Min(this IEnumerable<long> source)
        {
            return Min(source, (a) => { return a; }, LongComparer.Default);
        }
        public static float Min(this IEnumerable<float> source)
        {
            return Min(source, (a) => { return a; }, FloatComparer.Default);
        }
        public static double Min(this IEnumerable<double> source)
        {
            return Min(source, (a) => { return a; }, DoubleComparer.Default);
        }
        public static decimal Min(this IEnumerable<decimal> source)
        {
            return Min(source, (a) => { return a; }, DecimalComparer.Default);
        }
        public static DateTime Min(this IEnumerable<DateTime> source)
        {
            return Min(source, (a) => { return a; }, DateTimeComparer.Default);
        }

        public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, int max = 1)
        {
            return MinMax(source, selector, comparer, -1);
        }

        public static byte Max(this IEnumerable<byte> source)
        {
            return Max(source, (a) => { return a; }, ByteComparer.Default);
        }
        public static int Max(this IEnumerable<int> source)
        {
            return Max(source, (a) => { return a; }, IntComparer.Default);
        }
        public static long Max(this IEnumerable<long> source)
        {
            return Max(source, (a) => { return a; }, LongComparer.Default);
        }
        public static float Max(this IEnumerable<float> source)
        {
            return Max(source, (a) => { return a; }, FloatComparer.Default);
        }
        public static double Max(this IEnumerable<double> source)
        {
            return Max(source, (a) => { return a; }, DoubleComparer.Default);
        }
        public static decimal Max(this IEnumerable<decimal> source)
        {
            return Max(source, (a) => { return a; }, DecimalComparer.Default);
        }
        public static DateTime Max(this IEnumerable<DateTime> source)
        {
            return Max(source, (a) => { return a; }, DateTimeComparer.Default);
        }

        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, int max = 1)
        {
            return MinMax(source, selector, comparer, 1);
        }

        private static TResult MinMax<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, int max = 1)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            if (source.Count() < 1)
                throw new InvalidOperationException("source.Count() == 0");


            using (var ie = source.GetEnumerator())
            {
                TResult v1 = default(TResult), v2;
                if (ie.MoveNext())
                    v1 = selector(ie.Current);       //前面保证这一步肯定可以执行
                TAG:
                if (ie.MoveNext())
                {
                    v2 = selector(ie.Current);
                    if (comparer.Compare(v1, v2) * max < 0)
                        v1 = v2;
                    goto TAG;
                }
                return v1;
            }
        }

        public static byte Sum(this IEnumerable<byte> source)
        {
            return Sum(source, (a) => { return a; }, ByteComparer.Default.Plus);
        }

        public static int Sum(this IEnumerable<int> source)
        {
            return Sum(source, (a) => { return a; }, IntComparer.Default.Plus);
        }

        public static long Sum(this IEnumerable<long> source)
        {
            return Sum(source, (a) => { return a; }, LongComparer.Default.Plus);
        }

        public static float Sum(this IEnumerable<float> source)
        {
            return Sum(source, (a) => { return a; }, FloatComparer.Default.Plus);
        }

        public static double Sum(this IEnumerable<double> source)
        {
            return Sum(source, (a) => { return a; }, DoubleComparer.Default.Plus);
        }

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            return Sum(source, (a) => { return a; }, DecimalComparer.Default.Plus);
        }

        public static TResult Sum<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Func<TResult, TResult, TResult> plus)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");
            if (plus == null)
                throw new ArgumentNullException("plus");
            if (source.Count() < 1)
                throw new InvalidOperationException("source.Count() == 0");

            using (var ie = source.GetEnumerator())
            {
                TResult v1 = default(TResult);
                if (ie.MoveNext())
                    v1 = selector(ie.Current);       //前面保证这一步肯定可以执行
                TAG:
                if (ie.MoveNext())
                {
                    v1 = plus(v1, selector(ie.Current));
                    goto TAG;
                }
                return v1;
            }
        }


        public static byte Average(this IEnumerable<byte> source)
        {
            byte sum = Sum(source);
            return (byte)(sum / source.Count());
        }
        public static int Average(this IEnumerable<int> source)
        {
            int sum = Sum(source);
            return sum / source.Count();
        }
        public static long Average(this IEnumerable<long> source)
        {
            long sum = Sum(source);
            return sum / source.Count();
        }
        public static float Average(this IEnumerable<float> source)
        {
            float sum = Sum(source);
            return sum / source.Count();
        }
        public static double Average(this IEnumerable<double> source)
        {
            double sum = Sum(source);
            return sum / source.Count();
        }

        public static decimal Average(this IEnumerable<decimal> source)
        {
            decimal sum = Sum(source);
            return sum / source.Count();
        }

        public static TResult Average<TSource, TResult>(this IEnumerable<TSource> source
            , Func<TSource, TResult> selector
            , Func<TResult, TResult, TResult> plus
            , Func<TResult, int, TResult> devide)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");
            if (devide == null)
                throw new ArgumentNullException("plus");
            int count = source.Count();
            if (count < 1)
                throw new InvalidOperationException("source.Count() == 0");

            TResult sum = Sum(source, selector, plus);

            return devide(sum, count);
        }


        /// <summary>
        /// 返回一个只读的一键对多值的数据字典
        /// 每个值集合中允许重复对象
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="eleSelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static ILookup<TKey, TElement> Lookup<TKey, TSource, TElement>(this IEnumerable<TSource> source
            , Func<TSource, TKey> keySelector
            , Func<TSource, TElement> eleSelector
            , IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (eleSelector == null)
                throw new ArgumentNullException("eleSelector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            

            LookUp<TKey, TElement> lookup = new LookUp<TKey, TElement>(comparer);
            foreach (var each in source)
            {
                TKey key = keySelector(each);
                TElement ele = eleSelector(each);
                Group<TKey, TElement> group;
                if (!lookup.TryGetValue(key, out group))
                {
                    //建立字典映射并加入数据集合
                    group = lookup.Dict[key] = new Group<TKey, TElement>()
                    {
                        Key = key
                    };
                    lookup.AllGroup.Add(group);
                }
                group.List.Add(ele);
            }
            return lookup;
        }

        class Group<TKey, TElement> : IGrouping<TKey, TElement>
        {
            public TKey Key { get; set; }
            public List<TElement> List = new List<TElement>();
            public IEnumerator<TElement> GetEnumerator()
            {
                return List.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return List.GetEnumerator();
            }
        }

        class LookUp<TKey, TElement>: ILookup<TKey, TElement>
        {
            public Dictionary<TKey, Group<TKey, TElement>> Dict;
            /// <summary>
            /// 理论上使用Dict.Values即可达到效果,不过懒的再做类型转换了,直接再加个list保存
            /// </summary>
            public List<IGrouping<TKey, TElement>> AllGroup = new List<IGrouping<TKey, TElement>>();
            public LookUp(IEqualityComparer<TKey> comparer)
            {
                Dict = new Dictionary<TKey, Group<TKey, TElement>>(comparer);
            }

            public IEnumerable<TElement> this[TKey key]
            {
                get
                {
                    return Dict[key].List;
                }
            }
            public int Count { get { return Dict.Count; } }
            public bool Contains(TKey key)
            {
                return Dict.ContainsKey(key);
            }

            public bool TryGetValue(TKey key, out Group<TKey, TElement> ele)
            {
                return Dict.TryGetValue(key, out ele);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return AllGroup.GetEnumerator();
            }

            public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
            {
                return AllGroup.GetEnumerator();
            }
        }
    }




    public interface IGrouping<TKey, TElement> : IEnumerable, IEnumerable<TElement>
    {
        TKey Key { get; }
    }

    public interface ILookup<TKey, TElement> : IEnumerable, IEnumerable<IGrouping<TKey, TElement>>
    {
        IEnumerable<TElement> this[TKey key] { get; }

        int Count { get; }

        bool Contains(TKey key);

    }

    public interface IPlusDivide<T, T2>
    {
        T Plus(T t1, T t2);
        T Devide(T t1, T2 t2);
    }
}
