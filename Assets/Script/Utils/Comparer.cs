using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{ 

    public abstract class OrderByComparer<T> : IComparer<T>
    {
        public abstract int Compare(T x, T y);
    }

    public class OrderByComparer<T, TKey> : OrderByComparer<T>, IComparer<T>
    {
        public Func<T, TKey> KeySelector { get; set; }
        public IComparer<TKey> KeyComparer { get; set; }
        public bool Descending { get; set; }
        public override int Compare(T x, T y)
        {
            int ret = KeyComparer.Compare(KeySelector(x), KeySelector(y));
            if (Descending)
                ret *= -1;
            return ret;
        }
    }

    public class OrderByInt<T> : OrderByComparer<T, IntEx>, IComparer<T>
    {
        public OrderByInt(Func<T, IntEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = IntEx.Default;
            Descending = descending;
        }
    }
    public class OrderByLong<T> : OrderByComparer<T, IntEx>, IComparer<T>
    {
        public OrderByLong(Func<T, IntEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = IntEx.Default;
            Descending = descending;
        }
    }

    public class OrderByFloat<T> : OrderByComparer<T, FloatEx>, IComparer<T>
    {
        public OrderByFloat(Func<T, FloatEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = FloatEx.Default;
            Descending = descending;
        }
    }
    public class OrderByDouble<T> : OrderByComparer<T, FloatEx>, IComparer<T>
    {
        public OrderByDouble(Func<T, FloatEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = FloatEx.Default;
            Descending = descending;
        }
    }

    public class OrderByByte<T> : OrderByComparer<T, IntEx>, IComparer<T>
    {
        public OrderByByte(Func<T, IntEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = IntEx.Default;
            Descending = descending;
        }
    }

    public class OrderByString<T> : OrderByComparer<T, string>, IComparer<T>
    {
        public OrderByString(Func<T, string> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = StringComparer.Default;
            Descending = descending;
        }
    }

    public class OrderByDateTime<T> : OrderByComparer<T, DateTime>, IComparer<T>
    {
        public OrderByDateTime(Func<T, DateTime> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = DateTimeComparer.Default;
            Descending = descending;
        }
    }

    public class OrderByDecimal<T> : OrderByComparer<T, FloatEx>, IComparer<T>
    {
        public OrderByDecimal(Func<T, FloatEx> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = FloatEx.Default;
            Descending = descending;
        }
    }


    public class OrderByBoolean<T> : OrderByComparer<T, bool>, IComparer<T>
    {
        public OrderByBoolean(Func<T, bool> selector, bool descending)
        {
            KeySelector = selector;
            KeyComparer = BooleanComparer.Default;
            Descending = descending;
        }
    }

    public class IntComparer : IEqualityComparer<int>, IComparer<int>, IPlusDivide<int, int>, IEqualityComparer
    {
        public readonly static IntComparer Default = new IntComparer();

        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int x)
        {
            return x;
        }

        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return int.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public int Plus(int v1, int v2)
        {
            return v1 + v2;
        }

        public int Devide(int t1, int t2)
        {
            return t1 / t2;
        }
    }

    public class LongComparer : IEqualityComparer<long>, IComparer<long>, IPlusDivide<long, int>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static LongComparer Default = new LongComparer();

        public bool Equals(long x, long y)
        {
            return x == y;
        }

        public int GetHashCode(long x)
        {
            return x.GetHashCode();
        }

        public int Compare(long x, long y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return long.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public long Plus(long v1, long v2)
        {
            return v1 + v2;
        }
        public long Devide(long t1, int t2)
        {
            return t1 / t2;
        }
    }

    public class FloatComparer : IEqualityComparer<float>, IComparer<float>, IPlusDivide<float, int>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static FloatComparer Default = new FloatComparer();
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float x)
        {
            return x.GetHashCode();
        }

        public int Compare(float x, float y)
        {
            return x.CompareTo(y);
        }

        public new bool Equals(object x, object y)
        {
            return float.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public float Plus(float v1, float v2)
        {
            return v1 + v2;
        }
        public float Devide(float t1, int t2)
        {
            return t1 / t2;
        }
    }

    public class DoubleComparer : IEqualityComparer<double>, IComparer<double>, IPlusDivide<double, int>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static DoubleComparer Default = new DoubleComparer();
        public bool Equals(double x, double y)
        {
            return x == y;
        }

        public int GetHashCode(double x)
        {
            return x.GetHashCode();
        }

        public int Compare(double x, double y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return double.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public double Plus(double v1, double v2)
        {
            return v1 + v2;
        }
        public double Devide(double t1, int t2)
        {
            return t1 / t2;
        }
    }
    public class ByteComparer : IEqualityComparer<byte>, IComparer<byte>, IPlusDivide<byte, int>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static ByteComparer Default = new ByteComparer();
        public bool Equals(byte x, byte y)
        {
            return x == y;
        }

        public int GetHashCode(byte x)
        {
            return x.GetHashCode();
        }

        public int Compare(byte x, byte y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return byte.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public byte Plus(byte v1, byte v2)
        {
            return (byte)(v1 + v2);
        }
        public byte Devide(byte t1, int t2)
        {
            return (byte)(t1 / t2);
        }
    }


    public class DecimalComparer : IEqualityComparer<decimal>, IComparer<decimal>, IPlusDivide<decimal, int>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static DecimalComparer Default = new DecimalComparer();
        public bool Equals(decimal x, decimal y)
        {
            return x == y;
        }

        public int GetHashCode(decimal x)
        {
            return x.GetHashCode();
        }

        public int Compare(decimal x, decimal y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return decimal.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        public decimal Plus(decimal v1, decimal v2)
        {
            return v1 + v2;
        }
        public decimal Devide(decimal t1, int t2)
        {
            return t1 / t2;
        }
    }

    public class DateTimeComparer : IEqualityComparer<DateTime>, IComparer<DateTime>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static DateTimeComparer Default = new DateTimeComparer();
        public bool Equals(DateTime x, DateTime y)
        {
            return x == y;
        }

        public int GetHashCode(DateTime x)
        {
            return x.GetHashCode();
        }

        public int Compare(DateTime x, DateTime y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return DateTime.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

    }

    public class StringComparer : IEqualityComparer<string>, IComparer<string>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static StringComparer Default = new StringComparer();
        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode(string x)
        {
            return x.GetHashCode();
        }

        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return string.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }

    public class BooleanComparer : IEqualityComparer<bool>, IComparer<bool>, IEqualityComparer
    {
        public bool Descending = false;

        public readonly static BooleanComparer Default = new BooleanComparer();
        public bool Equals(bool x, bool y)
        {
            return x == y;
        }

        public int GetHashCode(bool x)
        {
            return x.GetHashCode();
        }

        public int Compare(bool x, bool y)
        {
            return x.CompareTo(y);
        }
        public new bool Equals(object x, object y)
        {
            return bool.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

    }

    public sealed class IntEx : IComparable, IComparable<IntEx>, IEqualityComparer ,IEqualityComparer<IntEx>, IComparer<IntEx>, IPlusDivide<IntEx, IntEx>
    {
        public long Value;
        public static readonly IntEx Default = new IntEx();

        public IntEx Plus(IntEx t1, IntEx t2)
        {
            return t1.Value + t2.Value;
        }
        public IntEx Devide(IntEx t1, IntEx t2)
        {
            return t1.Value / t2.Value;
        }

        public int Compare(IntEx x, IntEx y)
        {
            return x.Value.CompareTo(y.Value);
        }

        public new bool Equals(object x, object y)
        {
            if (x is IntEx && y is IntEx)
            {
                return long.Equals((x as IntEx).Value, (y as IntEx).Value);
            }
            else
            {
                return Equals(x, y);
            }
        }

        public int GetHashCode(object obj) {
            return (obj as IntEx).Value.GetHashCode();
        }

        public bool Equals(IntEx x, IntEx y)
        {
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(IntEx obj)
        {
            return obj.Value.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo((obj as IntEx).Value);
        }
        public int CompareTo(IntEx other)
        {
            return Value.CompareTo(other.Value);
        }

        public static implicit operator int (IntEx ex)
        {
            return (int)ex.Value;
        }
        public static implicit operator IntEx(int value)
        {
            return new IntEx() { Value = value };
        }

        public static implicit operator uint (IntEx ex)
        {
            return (uint)ex.Value;
        }
        public static implicit operator IntEx(uint value)
        {
            return new IntEx() { Value = value };
        }

        public static implicit operator long (IntEx ex)
        {
            return (long)ex.Value;
        }
        public static implicit operator IntEx(long value)
        {
            return new IntEx() { Value = value };
        }
        public static implicit operator short (IntEx ex)
        {
            return (short)ex.Value;
        }
        public static implicit operator IntEx(short value)
        {
            return new IntEx() { Value = value };
        }
        public static implicit operator ushort (IntEx ex)
        {
            return (ushort)ex.Value;
        }
        public static implicit operator IntEx(ushort value)
        {
            return new IntEx() { Value = value };
        }
        public static implicit operator byte (IntEx ex)
        {
            return (byte)ex.Value;
        }
        public static implicit operator IntEx(byte value)
        {
            return new IntEx() { Value = value };
        }
        public static implicit operator sbyte (IntEx ex)
        {
            return (sbyte)ex.Value;
        }
        public static implicit operator IntEx(sbyte value)
        {
            return new IntEx() { Value = value };
        }
    }

    public sealed class FloatEx : IComparable, IComparable<FloatEx>, IEqualityComparer, IEqualityComparer<FloatEx>, IComparer<FloatEx>, IPlusDivide<FloatEx, IntEx>
    {
        public double Value;
        public static readonly FloatEx Default = new FloatEx();

        public FloatEx Plus(FloatEx t1, FloatEx t2)
        {
            return t1.Value + t2.Value;
        }
        public FloatEx Devide(FloatEx t1, IntEx t2)
        {
            return t1.Value / t2.Value;
        }

        public int Compare(FloatEx x, FloatEx y)
        {
            return x.Value.CompareTo(y.Value);
        }

        public new bool Equals(object x, object y)
        {
            if (x is FloatEx && y is FloatEx)
            {
                return long.Equals((x as FloatEx).Value, (y as FloatEx).Value);
            }
            else
            {
                return Equals(x, y);
            }
        }

        public int GetHashCode(object obj)
        {
            return (obj as FloatEx).Value.GetHashCode();
        }

        public bool Equals(FloatEx x, FloatEx y)
        {
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(FloatEx obj)
        {
            return obj.Value.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo((obj as FloatEx).Value);
        }
        public int CompareTo(FloatEx other)
        {
            return Value.CompareTo(other.Value);
        }

        public static implicit operator float (FloatEx ex)
        {
            return (float)ex.Value;
        }
        public static implicit operator FloatEx(float value)
        {
            return new FloatEx() { Value = value };
        }

        public static implicit operator double (FloatEx ex)
        {
            return (double)ex.Value;
        }
        public static implicit operator FloatEx(double value)
        {
            return new FloatEx() { Value = value };
        }

        public static implicit operator decimal (FloatEx ex)
        {
            return new Decimal(ex.Value);
        }
        public static implicit operator FloatEx(decimal value)
        {
            return new FloatEx() { Value = decimal.ToDouble(value)  };
        }
    }
}

