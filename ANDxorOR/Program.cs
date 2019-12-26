using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ANDxorOR
{
    class Program
    {
        static int max = 0;

        static int andXorOr(int[] a)
        {
            int max = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                var m1 = a[i];
                var m2 = a[i + 1];

                var and = m1 & m2;
                var or = m1 | m2;
                var xOr = m1 ^ m2;

                var xOr2 = and ^ or;
                var s = xOr2 & xOr;

                if (s > max)
                {
                    max = s;

                    Console.WriteLine($"[{m1}, {m2}] => max= {max}");
                }

            }
            return max;
        }

        /// <summary>
        /// Editorial
        /// </summary>
        static int andXorOr2(int[] a)
        {
            var s = new Stack<int>();

            int result = 0, cur = 0;

            for (int i = 0; i < a.Length; ++i)
            {
                while (s.Count > 0 && s.Peek() >= a[i])
                {

                    int tmp = s.Peek(); s.Pop();
                    result = Math.Max(result, tmp ^ a[i]);
                }

                if (s.Count > 0) result = Math.Max(result, a[i] ^ s.Peek());
                s.Push(a[i]);
            }

            return result;
        }

        public static void CalcMax(int m1, int m2)
        {
            var s = m1 ^ m2;
            //var and = m1 & m2;
            //var or = m1 | m2;
            //var xOr = m1 ^ m2;

            //var xOr2 = and ^ or;
            //var s = xOr2 & xOr;

            if (s > max)
            {
                max = s;
                //Console.WriteLine($"[{m1}, {m2}] => max= {max}");

            }
            //Console.WriteLine($"[{m1}, {m2}] => max= {max}");

        }

        /// <summary>
        ///  Pure O(n2) solution
        /// </summary>
        static int andXorOr3(int[] a)
        {
            int max = 0;
            var ss = new int[a.Length];

            for (int i = 0; i < a.Length - 1; i++)
            {
                int m1 = int.MaxValue, m2 = int.MaxValue;

                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] <= m1)
                    {
                        m2 = m1;
                        m1 = a[j];

                        if (m2 == int.MaxValue)
                            continue;
                    }
                    else if (a[j] < m2)
                        m2 = a[j];
                    else
                        continue;

                    int s;

                    if (ss[j] == 0)
                    {
                        var and = m1 & m2;
                        var or = m1 | m2;
                        var xOr = m1 ^ m2;

                        var xOr2 = and ^ or;
                        s = xOr2 & xOr;

                        ss[j] = s;
                    }
                    else
                        s = ss[j];

                    if (s > max)
                    {
                        max = s;
                        Console.WriteLine($"{i}, {j} => [{m1}, {m2}] => max= {max}");
                    }

                }
            }
            return max;
        }

        /// <summary>
        /// Final Solution
        /// </summary>
        static int andXorOr4(int[] a)
        {
            var stack = new Stack<int>();

            stack.Push(a[0]);

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > stack.Peek())
                {
                    CalcMax(a[i], stack.Peek());

                    stack.Push(a[i]);
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek() > a[i])
                    {
                        CalcMax(a[i], stack.Peek());
                        stack.Pop();
                    }
                    if (stack.Count > 0)
                        CalcMax(a[i], stack.Peek());

                    stack.Push(a[i]);
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int aCount = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            var sw = new Stopwatch();
            sw.Start();

            int result = andXorOr4(a);

            sw.Stop();

            Console.WriteLine($"time: {sw.Elapsed.TotalMilliseconds}");
            Console.WriteLine($"result: {result}");
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
