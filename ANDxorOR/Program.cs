using System;
using System.Collections.Generic;

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

        static int andXorOr2(int[] a)
        {
            int m1I = 0;
            int m1 = int.MaxValue, m2 = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < m1)
                {
                    m2 = m1;
                    m1 = a[i];

                    m1I = i;

                    if (m2 == int.MaxValue)
                        continue;
                }
                else
                {
                    var min1 = a[i];
                    var min2 = a[i];
                    for (int j = i - 1; j > m1I; j--)
                    {
                        if (a[i] > min1 && a[i] > min2)
                            break;

                        if (min1 > a[j])
                        {
                            min1 = a[j];
                            min2 = min1;
                        }
                        else if (min2 > a[j])
                            min2 = a[j];

                        CalcMax(a[i], min1);
                    }

                    continue;
                }

                CalcMax(m1, m2);
            }

            return max;
        }

        public static void CalcMax(int m1, int m2)
        {
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
                    if(stack.Count > 0)
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
            int result = andXorOr4(a);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
