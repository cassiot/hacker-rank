using System;
using System.Collections.Generic;

namespace QueriesWithFixedLength
{
    class Program
    {
        static int[] solve(int[] arr, int[] queries)
        {
            var q = new Queue<int>();
            var mins = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int min = int.MaxValue, max = 0;
                int c = 1;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] > max)
                    {
                        max = arr[j];
                        q.Enqueue(arr[j]);

                    }

                    if (c == queries[i])
                    {
                        min = Math.Min(min, max);
                        var d = arr[j - (c - 1)];

                        if (d == max)
                        {
                            j -= (c - 1);
                            max = 0;
                            q.Clear();
                            c = 1;
                        }
                    }
                    else
                        c++;
                }

                mins[i] = min;
            }

            return mins;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;

            int[] queries = new int[q];

            for (int queriesItr = 0; queriesItr < q; queriesItr++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine());
                queries[queriesItr] = queriesItem;
            }

            int[] result = solve(arr, queries);

            //textWriter.WriteLine(string.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
