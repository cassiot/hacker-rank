using System;
using System.Collections.Generic;

namespace DownToZeroII
{
    class Program
    {
        class NCount
        {
            public int n;
            public int count;
            //public NCount parent;
        }

        static Dictionary<int, int> dic = new Dictionary<int, int>();
        static Queue<NCount> q;

        static int downToZero(int n)
        {
            int count, minCount = int.MaxValue;
            q = new Queue<NCount>();
            q.Enqueue(new NCount() { n = n, count = 0 });

            while (q.Count > 0)
            {
                n = q.Peek().n;
                count = q.Peek().count;

                if (n > 3 && count > minCount - 4)
                {
                    q.Dequeue();
                    continue;
                }

                if (n > 3)
                    FindFactors(n, count);//, q.Peek());

                if (n > 1)
                    Enqueue(n - 1, count + 1);//, q.Peek());

                if (n == 1)
                    minCount = Math.Min(count + 1, minCount);

                q.Dequeue();
            }

            if (minCount == int.MaxValue)
                minCount = 0;

            return minCount;
        }

        static void FindFactors(int n, int count)//, NCount parent)
        {
            int i = 2;
            while (i * i <= n)
            {
                if (n % i == 0)
                    Enqueue(n / i, count + 1);//, parent);
                i++;
            }
        }

        static void Enqueue(int n, int count)//, NCount parent)
        {
            if (dic.ContainsKey(n))
            {
                if (dic[n] > count)
                {
                    q.Enqueue(new NCount() { n = n, count = count });//, parent = parent });
                    dic[n] = count;
                }
            }
            else
            {
                q.Enqueue(new NCount() { n = n, count = count });//, parent = parent });
                dic.Add(n, count);
            }
        }

        static void GeneratePrimes(int n)
        {
            var primes = new List<int>();
            primes.Add(2);
            primes.Add(3);
            primes.Add(5);

            for (int i = 7; i <= n; i += 2)
            {
                if (i % 5 == 0)
                    continue;

                var isPrime = true;
                foreach (var p in primes)
                {
                    if (p > i)
                        break;

                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    primes.Add(i);
            }
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                //if (qItr == 2)
                //{
                int result = downToZero(n);
                dic.Clear();
                Console.WriteLine($"{n} => {result}");
                //}
                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
