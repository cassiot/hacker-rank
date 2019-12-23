using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;

namespace GameOfTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@"c:\temp", true);

            //twoStacks(10, new[] { 4, 2, 4, 6, 1, }, new[] { 2, 1, 8, 5 });

            //var s1 = twoStacks(12, new[] { 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }, new[] { 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 });
            //var s2 = twoStacks(5, new[] { 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 }, new[] {1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0});
            int g = Convert.ToInt32(Console.ReadLine());
            var l = new List<int>();
            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] nmx = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmx[0]);

                int m = Convert.ToInt32(nmx[1]);

                int x = Convert.ToInt32(nmx[2]);

                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
                int result = twoStacks2(x, a, b);

                //l.Add(result);
                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }

        static int twoStacks2(int x, int[] a, int[] b)
        {
            int i = -1, j = 0;
            long sumA = 0, sumB = 0;
            int max = 0;
            var bSums = new SortedList<long, int>();

            while (j < b.Length)
            {
                sumB += b[j];

                if (sumB > x)
                    break;

                if (bSums.ContainsKey(sumB))
                    bSums[sumB] = j;
                else
                    bSums.Add(sumB, j);

                j++;
            }

            sumB = 0;
            var k = 0;
            j = bSums.Count - 1;

            if (j > -1)
            {
                sumB = bSums.Keys[j];
                k = bSums.Values[j] + 1;
            }


            while (i < a.Length)
            {
                if (i > -1)
                    sumA += a[i];

                if (sumA > x)
                {
                    if(i == 0 && j == -1)
                        return 0;

                    break;
                }

                while (sumA + sumB > x)
                {
                    if (j < 0)
                    {
                        sumB = 0;
                        k = 0;
                        break;
                    }

                    sumB = bSums.Keys[j];
                    k = bSums.Values[j]  + 1;

                    j--;
                }

                if (i + k > max)
                    max = i + k;

                i++;
            }

            if (i > -1)
                max++;

            return max;
        }
    }
}
