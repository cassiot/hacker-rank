using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PoisonousPlants
{
    class Program
    {
        static int algo = 5;
        static int print = 0;

        static int index = -10;
        static Stack<Tuple<int, int, int>> maxStack = new Stack<Tuple<int, int, int>>();
        static int max = 0;

        static Dictionary<int, List<int>> daysDic = new Dictionary<int, List<int>>();

        /// <summary>
        /// Hacker Rank editorial solution
        /// </summary>
        static int poisonousPlants8(int[] p)
        {
            var s = new Stack<KeyValuePair<int, int>>();
            int maxa = 0;
            int n = p.Length;

            for (int i = 0; i < n; i++)
            {
                p[i] = -p[i];
            }

            for (int i = 0; i < n; i++)
            {
                if (s.Count == 0)
                {
                    s.Push(new KeyValuePair<int, int>(p[i], 0));
                }
                else
                {
                    var temp = s.Peek();

                    if (p[i] < temp.Key)
                    {
                        int sc = 1;
                        maxa = Math.Max(maxa, sc);
                        s.Push(new KeyValuePair<int, int>(p[i], sc));
                    }
                    else
                    {
                        var v = s.Peek();
                        int pr = v.Value;
                        while (s.Count > 0 && v.Key <= p[i])
                        {
                            s.Pop();
                            if (s.Count == 0)
                                break;
                            pr = Math.Max(pr, v.Value);
                            v = s.Peek();
                        }

                        if (s.Count == 0)
                        {
                            s.Push(new KeyValuePair<int, int>(p[i], 0));
                        }

                        else
                        {
                            s.Push(new KeyValuePair<int, int>(p[i], pr + 1));
                            maxa = Math.Max(maxa, pr + 1);
                        }
                    }
                }
            }

            return maxa;
        }

        /// <summary>
        /// Solução retirada do forum do HackerRank para fins comparativos
        /// </summary>
        static int poisonousPlants7(int[] p)
        {
            int[] days = new int[p.Length];
            int min = p[0];
            int max = 0;
            Stack<int> pila = new Stack<int>();

            pila.Push(0);

            for (int x = 1; x < p.Length; x++)
            {
                if (p[x] > p[x - 1])
                    days[x] = 1;

                min = min < p[x] ? min : p[x];

                while (pila.Count > 0 && p[pila.Peek()] >= p[x])
                {
                    if (p[x] > min)
                        days[x] = days[x] > days[pila.Peek()] + 1 ? days[x] : days[pila.Peek()] + 1;

                    pila.Pop();
                }

                max = max > days[x] ? max : days[x];
                pila.Push(x);

            }

            return max;
        }

        /// <summary>
        /// Solução final que funcionou
        /// </summary>
        /// 
        public struct Plant
        {
            public int Key;
            public int Count;
        }

        static int poisonousPlants6(int[] p)
        {
            int count = 0;
            int min = p[0];
            var lastCounts = new Stack<Plant>();
            lastCounts.Push(new Plant() { Key = p[0], Count = 0 });

            for (int i = 1; i < p.Length; i++)
            {
                var current = p[i];
                var previous = p[i - 1];

                if (current > previous)
                    count = 1;
                else
                {
                    if (current <= min)
                    {
                        min = current;
                        count = 0;

                        //if (max >= p.Length - i)
                        //    break;
                    }
                    else
                    {
                        bool popped = false;
                        while (lastCounts.Count > 0 && current <= lastCounts.Peek().Key)
                        {
                            var pop = lastCounts.Pop();
                            popped = true;

                            count = Math.Max(count, pop.Count + 1);
                        }

                        if (!popped)
                            count++;
                    }

                    lastCounts.Push(new Plant() { Key = current, Count = count });
                }

                max = Math.Max(count, max);
            }

            return max;
        }

        /// <summary>
        /// Solução que passa em quase todos os testes mas falha em 2
        /// </summary>
        static int poisonousPlants5(int[] p)
        {
            int i = 1, count = 0;

            maxStack.Push(new Tuple<int, int, int>(0, p[0], p[0]));

            int min = p[0];
            KeyValuePair<int, int> lastCount = new KeyValuePair<int, int>();
            KeyValuePair<int, int> lastMax = new KeyValuePair<int, int>();

            while (i < p.Length)
            {
                var current = p[i];
                var previous = p[i - 1];

                if (current > previous)
                {
                    //if (count > 1)//if (count >= lastCount.Value)
                    //    lastCount = new KeyValuePair<int, int>(previous, count);

                    //if (count == 0)
                    count = 1;
                }
                else
                {
                    if (current <= min)
                    {
                        min = current;
                        count = 0;
                        lastCount = new KeyValuePair<int, int>(0, 0);
                        lastMax = new KeyValuePair<int, int>(0, 0);
                    }
                    else if (current <= lastMax.Key)
                    {
                        count = lastMax.Value + 1;
                        //lastMax = new KeyValuePair<int, int>(current, count);
                        lastCount = new KeyValuePair<int, int>(current, count);
                    }
                    else if (current <= lastCount.Key)
                    {
                        count = lastCount.Value + 1;
                        lastCount = new KeyValuePair<int, int>(current, count);
                    }
                    else
                    {
                        count++;

                        //if (count >= lastCount.Value)
                        lastCount = new KeyValuePair<int, int>(current, count);
                    }

                    if (count >= lastMax.Value)
                        lastMax = new KeyValuePair<int, int>(current, count);

                }

                CheckMax(ref count, current, min);

                i++;
            }

            //if (minBases.Count < 10)
            //    Console.WriteLine(string.Join(" ", minBases));

            //if (bases.Count < 10)
            //    Console.WriteLine(string.Join(" ", bases));

            return maxStack.Peek().Item1;// > count ? max : count;
        }

        private static void CheckMax(ref int count, int value, int min)
        {
            if (maxStack.Peek().Item1 == count && value <= maxStack.Peek().Item2)
            {
                max = count;
                //maxStack.Push(new Tuple<int, int, int>(count, value, min));
            }

            if (maxStack.Peek().Item1 < count)
            {
                max = count;
                //maxStack.Push(new Tuple<int, int, int>(count, value, min));
            }

            if (daysDic.ContainsKey(count))
                daysDic[count].Add(value);
            else
                daysDic.Add(count, new List<int>() { value });

        }

        static int poisonousPlants4(int[] p)
        {
            var l = new List<int>(p);
            var i = p.Length - 1;
            int max = 0;
            bool removed = false;
            int lastI = i;
            int minI = 1;

            while (true)
            {
                var item = l[i];

                if (l[i - 1] < l[i])
                {

                    if (removed == false)
                        max++;

                    if (daysDic.ContainsKey(max))
                        daysDic[max].Insert(0, item);
                    else
                        daysDic.Add(max, new List<int>() { item });

                    l.RemoveAt(i);
                    if (l.Count == 1)
                        break;

                    removed = true;
                    lastI = i;
                }

                if (i == minI)
                {
                    if (removed)
                    {
                        i = l.Count - 1;
                        removed = false;
                        minI = lastI > 1 ? lastI - 1 : 1;

                        //if (l.Count < print)
                        //{
                        //    Console.WriteLine(string.Join(" ", l));
                        //    Console.WriteLine();
                        //}

                        continue;
                    }

                    break;
                }

                i--;
            }

            return max;
        }

        static int poisonousPlants2(int[] p)
        {
            var i = index == -10 ? p.Length - 2 : index;

            int last, current, count = 1;
            int max = 0;

            //if (i < 0) count = 0;

            while (i >= 0)
            {
                current = p[i];
                last = p[i + 1];

                if (current >= last)
                    count++;
                else
                {
                    index = i - 1;
                    count--;

                    count += poisonousPlants2(p);

                    if (max < count)
                        max = count;

                    i = index;
                }

                i--;
            }

            return max;
        }

        static int poisonousPlants(int[] p)
        {
            int days = 0;
            int count = 1;

            var stack = new Stack<int>();
            stack.Push(p[0]);

            for (int i = 0; i < p.Length; i++)
                stack.Push(p[i]);

            int lastCount = count;
            int previous = stack.Peek();

            while (stack.Count > 1)
            {
                var last = stack.Pop();
                var peek = stack.Peek();

                if (last <= peek)
                    count++;
                else
                {
                    if (previous > last)
                        continue;
                    if (previous < peek)
                        count--;
                    else
                        count = 1;
                }

                if (count > days)
                    days = count;

                previous = last;
            }

            return days;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "algo")
                    algo = int.Parse(args[i + 1]);

                if (args[i] == "print")
                    print = int.Parse(args[i + 1]);
            }

            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine());

            int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp));
            int result = 0;

            var sw = new Stopwatch();
            sw.Start();

            if (algo == 4)
                result = poisonousPlants4(p);
            else if (algo == 5)
                result = poisonousPlants5(p);
            else if (algo == 6)
                result = poisonousPlants6(p);
            else if (algo == 7)
                result = poisonousPlants7(p);
            else if (algo == 8)
                result = poisonousPlants8(p);

            sw.Stop();

            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            foreach (var day in daysDic)
            {
                if (day.Value.Count < print)
                {
                    Console.WriteLine(string.Join(" ", day.Value));
                    Console.WriteLine();
                }
            }

            //Console.WriteLine();
            //Console.WriteLine($"p: {p.Length}");
            Console.WriteLine($"result: {result}");

            Console.ReadLine();
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
