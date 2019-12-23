using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LargestRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp));
            long result = largestRectangle(h);
            Console.WriteLine();

            result = largestRectangleStack(h);
            Console.WriteLine();

            result = largestRectangle1(h);
            Console.WriteLine();

            result = largestRectangle2(h);
            Console.WriteLine();

            result = largestRectangle3(h);
            Console.WriteLine();

            Console.ReadLine();
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }

        static long largestRectangle(int[] h)
        {
            var sw = Stopwatch.StartNew();

            var dic = new Dictionary<int, int>();

            if (h.Length == 1)
                return h[0];

            var max = 0;

            for (int i = 0; i < h.Length; i++)
            {
                if (dic.ContainsKey(i))
                    continue;

                var ts = i;
                int j = i + 1;
                var sum = h[i];

                while (j < h.Length)
                {
                    if (dic.ContainsKey(j))
                        break;

                    if (h[j] >= h[ts])
                    {
                        sum += h[ts];
                        if (sum > max)
                            max = sum;
                    }
                    else
                    {
                        sum -= (j - i) * h[ts] - (j - i) * h[j];
                        sum += h[j];
                        if (sum > max)
                            max = sum;
                        ts = j;

                        if (dic.ContainsKey(j) == false)
                            dic.Add(j, j);
                    }

                    j++;
                }

                if (sum > max)
                    max = sum;
            }

            sw.Stop();
            Console.WriteLine("Result: " + max);
            Console.WriteLine("Elapsed Ticks: " + sw.ElapsedTicks);

            return max;
        }

        static int largestRectangleStack(int[] arr)
        {
            var sw = Stopwatch.StartNew();

            var stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i <= arr.Length; i++)
            {
                int h = (i == arr.Length) ? 0 : arr[i];

                if (!stack.Any() || arr[stack.Peek()] <= h)
                {
                    stack.Push(i);
                }
                else
                {
                    int top = stack.Pop();
                    maxArea = Math.Max(maxArea, arr[top] * (!stack.Any() ? i : i - stack.Peek() - 1));
                    i--;
                }
            }

            sw.Stop();
            Console.WriteLine("Result: " + maxArea);
            Console.WriteLine("Elapsed Ticks: " + sw.ElapsedTicks);

            return maxArea;
        }

        static int largestRectangle1(int[] h)
        {
            int n = h.Length;
            var sw = Stopwatch.StartNew();
            int i = 0, area = 0, Max = 0, currMax = 0;

            Stack<int> s = new Stack<int>();

            while (i < n)
            {
                if (s.Count == 0 || h[s.Peek()] <= h[i])
                {
                    s.Push(i);
                    i++;
                }
                else
                {
                    currMax = s.Pop();
                    area = h[currMax] * (s.Count > 0 ? (i - 1 - s.Peek()) : (i));
                    if (area > Max)
                        Max = area;
                }
            }
            while (s.Count > 0)
            {
                currMax = s.Pop();
                area = h[currMax] * (s.Count > 0 ? (i - 1 - s.Peek()) : (i));
                if (area > Max)
                    Max = area;
            }

            sw.Stop();
            Console.WriteLine("Result: " + Max);
            Console.WriteLine("Elapsed Ticks: " + sw.ElapsedTicks);

            return Max;
        }

        static int largestRectangle2(int[] h)
        {
            var sw = Stopwatch.StartNew();

            var max = 0;

            var pn = new Stack<int>();
            var ht = new Stack<int>();
            var cur = 0;

            foreach (var hist in h.Select((v, i) => new { pn = i, ht = v }))
            {
                if (pn.Count == 0 || hist.ht > ht.Peek())
                {
                    pn.Push(hist.pn);
                    ht.Push(hist.ht);
                }
                else
                {
                    var oldpn = 0;
                    do
                    {
                        oldpn = pn.Peek();
                        var area = (cur - pn.Pop()) * ht.Pop();
                        max = area > max ? area : max;
                    } while (pn.Count > 0 && hist.ht < ht.Peek());

                    // smaller height rect unhidden
                    pn.Push(oldpn);
                    ht.Push(hist.ht);
                }
                cur++; // needed after foreach (= hist.i)
            }
            while (pn.Count > 0) // get rest of areas
            {
                var area = (cur - pn.Pop()) * ht.Pop();
                max = area > max ? area : max;
            }

            sw.Stop();
            Console.WriteLine("Result: " + max);
            Console.WriteLine("Elapsed Ticks: " + sw.ElapsedTicks);

            return max;
        }

        static int largestRectangle3(int[] arr)
        {
            var sw = Stopwatch.StartNew();

            int maxArea = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int start = i;
                while (start > 0)
                {
                    if (arr[start - 1] >= arr[i])
                        start--;
                    else
                        break;
                }

                int end = i + 1;
                while (end < arr.Length)
                {
                    if (arr[end] >= arr[i])
                        end++;
                    else
                        break;
                }

                int area = arr[i] * (end - start);

                if (area > maxArea)
                    maxArea = area;
            }

            sw.Stop();
            Console.WriteLine("Result: " + maxArea);
            Console.WriteLine("Elapsed Ticks: " + sw.ElapsedTicks);

            return maxArea;
        }

    }
}
