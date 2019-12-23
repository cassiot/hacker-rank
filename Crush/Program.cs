using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Crush
{
    class Program
    {
        static void Main(string[] args)
        {
            case1();
            Console.ReadLine();

            case2();
            Console.ReadLine();

            case3();
            Console.ReadLine();

            case4();
            Console.ReadLine();

            case5();
            Console.ReadLine();
        }


        static long arrayManipulation(int n, int[][] queries)
        {
            var array = new long[n + 2];

            for (int i = 0; i < queries.Length; i++)
            {
                var q = queries[i];
                var a = q[0];
                var b = q[1];
                var k = q[2];

                array[a] += k;
                array[b + 1] -= k;
            }

            //1 5 3
            //4 8 7
            //6 9 1

            long sum = 0;
            long maxSum = 0;

            for (int i = 0; i <= n; i++)
            {
                sum += array[i];

                if (sum > maxSum)
                    maxSum = sum;
            }

            return maxSum;
        }

        //static long arrayManipulation(int n, int[][] queries)
        //{
        //    int currentMax = 10;

        //    var dicSums = new Dictionary<ulong, long>();
        //    long maxSum = 0;

        //    for (int i = 0; i < queries.Length; i++)
        //    {
        //        var q = queries[i];

        //        var k = ((ulong)Math.Pow(2, q[1] - q[0] + 1) - 1) << (n - q[1]);

        //        if (dicSums.Count == 0)
        //        {
        //            dicSums.Add(k, q[2]);
        //            maxSum = q[2];
        //            continue;
        //        }

        //        var dicAux = new Dictionary<ulong, long>();

        //        foreach (var kv in dicSums)
        //        {
        //            var auxKeyAnd = kv.Key & k;
        //            var auxKeyXor = kv.Key ^ k;

        //            if (auxKeyAnd == 0 || auxKeyXor == 0)
        //                continue;

        //            if (dicAux.ContainsKey(auxKeyAnd))
        //            {
        //                if (kv.Value > dicAux[auxKeyAnd])
        //                    dicAux[auxKeyAnd] = kv.Value + q[2];
        //            }
        //            else
        //            {
        //                dicAux.Add(auxKeyAnd, kv.Value + q[2]);
        //            }

        //            if (dicAux.ContainsKey(auxKeyXor))
        //            {
        //                if (kv.Value > dicAux[auxKeyXor])
        //                    dicAux[auxKeyXor] = q[2];
        //            }
        //            else
        //            {
        //                dicAux.Add(auxKeyXor, q[2]);
        //            }
        //        }

        //        foreach (var kv in dicAux)
        //        {
        //            if (dicSums.ContainsKey(kv.Key))
        //            {
        //                if (kv.Value > dicSums[kv.Key])
        //                    dicSums[kv.Key] = kv.Value;
        //            }
        //            else
        //                dicSums.Add(kv.Key, kv.Value);

        //            if (kv.Value > maxSum)
        //                maxSum = kv.Value;
        //        }

        //        if (dicSums.Count > currentMax)
        //        {
        //            Console.WriteLine($"CurrentMax: {dicSums.Count} i: {i}");
        //            currentMax *= 10;
        //        }
        //    }

        //    return maxSum;
        //}

        static void case1()
        {
            //5 3
            //1 2 100
            //2 5 100
            //3 4 100
            var queries = new int[3][];
            queries[0] = new int[] { 1, 2, 100 };
            queries[1] = new int[] { 2, 5, 100 };
            queries[2] = new int[] { 3, 4, 100 };

            var max = arrayManipulation(5, queries);
            Console.WriteLine($"Max= {max}");
        }

        static void case2()
        {
            //10 3
            //1 5 3
            //4 8 7
            //6 9 1

            var queries = new int[3][];
            queries[0] = new int[] { 1, 5, 3 };
            queries[1] = new int[] { 4, 8, 7 };
            queries[2] = new int[] { 6, 9, 1 };

            var max = arrayManipulation(10, queries);
            Console.WriteLine($"Max= {max}");
        }

        static void case3()
        {
            //10 4
            //2 6 8
            //3 5 7
            //1 8 1
            //5 9 15

            var queries = new int[4][];
            queries[0] = new int[] { 2, 6, 8 };
            queries[1] = new int[] { 3, 5, 7 };
            queries[2] = new int[] { 1, 8, 1 };
            queries[3] = new int[] { 5, 9, 15 };

            var max = arrayManipulation(10, queries);
            Console.WriteLine($"Max= {max}");
        }

        static void case4()
        {
            var queries = new int[4][];
            queries[0] = new int[] { 2, 6, 8 };
            queries[1] = new int[] { 3, 5, 7 };
            queries[2] = new int[] { 1, 8, 1 };
            queries[3] = new int[] { 5, 9, 15 };

            var max = arrayManipulation(10000000, queries);
            Console.WriteLine($"Max= {max}");
        }

        static void case5()
        {
            var lines = File.ReadAllLines("input12.txt");

            var line1 = lines[0].Split(" ");
            var n = int.Parse(line1[0]);
            var qLength = int.Parse(line1[1]);

            var queries = new int[qLength][];

            for (int i = 1; i <= qLength; i++)
            {
                var l = lines[i].Split(" ");
                queries[i - 1] = new int[] { int.Parse(l[0]), int.Parse(l[1]), int.Parse(l[2]) };
            }

            var max = arrayManipulation(n, queries);
            Console.WriteLine($"Max= {max}");
        }

        // Complete the arrayManipulation function below.
        //static long arrayManipulation(int n, int[][] queries)
        //{

        //    var a = new long[n];
        //    long max = 0;

        //    foreach (var q in queries)
        //    {
        //        for (int i = q[0] - 1; i < q[1]; i++)
        //        {
        //            a[i] += q[2];
        //        }
        //    }

        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i] > max)
        //            max = a[i];
        //    }
        //    return max;
        //}

    }
}
