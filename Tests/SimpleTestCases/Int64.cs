﻿using System;

interface L
{
    long Value { get; set; }
    long Getter();
    void Setter(long l);
}

class A : L
{
    public long Value { get; set; }
    public long Getter() { return Value; }
    public void Setter(long l) { Value = l; }
}

struct Foo
{
    public int X;
}

public class Program
{
    public const long TEST_CONST = 1000L;
    public readonly long TEST_READONLY_FIELD = 2000L;
    public static long TEST_STATIC_FIELD = 3000L;
    public long TEST_NORMAL_FIELD = 4000L;


    public static void Main(string[] args)
    {
        var x = 100000000000L;
        var y = 10000053450L;

        // literals
        Console.WriteLine(0L);
        Console.WriteLine(1000000000000L);
        Console.WriteLine(long.MaxValue);
        Console.WriteLine(long.MinValue);

        // fields
        Console.WriteLine(TEST_CONST);
        Console.WriteLine(new Program().TEST_READONLY_FIELD);
        Console.WriteLine(TEST_STATIC_FIELD);
        Console.WriteLine(new Program().TEST_NORMAL_FIELD);

        // addition
        Console.WriteLine(1000000000000L + x);
        Console.WriteLine(1L + 0L);
        Console.WriteLine(1L + x);
        Console.WriteLine(1L + -x);
        Console.WriteLine(1 + 0L);
        Console.WriteLine(1 + x);
        Console.WriteLine(1 + -x);

        // subtraction
        Console.WriteLine(1000000000000L - x);
        Console.WriteLine(1L - 0L);
        Console.WriteLine(1L - x);
        Console.WriteLine(1L - -x);
        Console.WriteLine(1 - 0L);
        Console.WriteLine(1 - x);
        Console.WriteLine(1 - -x);

        // conversion
        Console.WriteLine(((long)Math.Round(40.1d)) * x);
        Console.WriteLine((double)(x + y) + 123.5);

        // comparison
        WriteBool(x == y);
        WriteBool(x == x);
        WriteBool(x != y);
        WriteBool(x != x);
        WriteBool(x < y);
        WriteBool(x <= x);
        WriteBool(x > y);
        WriteBool(x >= x);

        Console.WriteLine(-x);
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(x + y);
        Console.WriteLine(x - y);
        Console.WriteLine(x * y);
        Console.WriteLine(x / y);
        Console.WriteLine(x % y);
        Console.WriteLine(x & y);
        Console.WriteLine(x | y);
        Console.WriteLine(x >> 3);
        Console.WriteLine(y << 3);
        Console.WriteLine(2 * x + 3 * y / 7);

        int z = 2;
        Console.WriteLine(((long)z) * x);

        int days = 100, hours = 20, minutes = 1, seconds = 1, milliseconds = 20;
        int hrssec = (hours * 3600); // break point at (Int32.MaxValue - 596523)
        int minsec = (minutes * 60);
        long t = ((long)(hrssec + minsec + seconds) * 1000L + (long)milliseconds);
        t *= 10000;
        Console.WriteLine(t);

        object box = Boxed();
        Console.WriteLine(x * (long)box);

        object bbox = BoxedFoo();
        Console.WriteLine(((Foo)bbox).X);

        var n = 634590720000000000L;
        var m = 864000000000L;
        Console.WriteLine(n);
        Console.WriteLine(m);
        Console.WriteLine(1 + (int)(n / m));

        Console.WriteLine(div(123, 333));

        var a = new A();
        a.Value = 45;
        Console.WriteLine(a.Value);
        a.Setter(n);
        Console.WriteLine(a.Value);

        L l = a;
        l.Value = m;
        Console.WriteLine(l.Getter());
    }

    public static object BoxedFoo()
    {
        return new Foo();
    }

    public static object Boxed()
    {
        return 634590720000000000L;
    }

    public static void WriteBool(bool b)
    {
        // System.Bool.ToString() is lower-case in JS
        Console.WriteLine(b ? "True" : "False");
    }

    public static int div(int x, int y)
    {
        return (int)Math.Floor((double)x / (double)y);
    }

}