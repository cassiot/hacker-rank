using System;
using System.Collections.Generic;
using System.IO;

namespace Waiter
{
    class Program
    {
        static int[] waiter(int[] number, int q)
        {
            var numberList = new List<int>(number);
            var primes = GeneratePrimes();
            //var c = Math.Min(primes.Count, q);
            var B = new List<int>();

            int i = 0;
            for (i = 0; i < q; i++)
            {
                var bSize = B.Count;
                for (int j = numberList.Count - 1; j >= 0; j--)
                {
                    if (numberList[j] % primes[i] == 0)
                    {
                        if (i % 2 == 1)
                            B.Add(numberList[j]);
                        else
                            B.Insert(bSize, numberList[j]);
                        numberList.RemoveAt(j);
                    }
                }
            }

            if (i % 2 == 0)
                numberList.Reverse();

            B.AddRange(numberList);

            return B.ToArray();
        }

        static List<int> GeneratePrimes()
        {
            var primes = new List<int>(new[] { 2 });

            for (int i = 3; i <= 50000; i += 2)
            {
                var isPrime = true;
                foreach (var p in primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    primes.Add(i);
            }

            return primes;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] number = Array.ConvertAll(Console.ReadLine().Split(' '), numberTemp => Convert.ToInt32(numberTemp));
            int[] result = waiter(number, q);


            if (args[0] == "vfile")
            {
                var lines = File.ReadAllLines(args[1]);
                Console.WriteLine("Conferindo...");
                Console.WriteLine("");
                for (int i = 0; i < result.Length; i++)
                {
                    if (int.Parse(lines[i]) != result[i])
                        Console.WriteLine($"Line {i} => expected {lines[i]} but got {result[i]}");
                }
            }
            if (args[0] == "ofile")
            {
                File.WriteAllLines(args[1], Array.ConvertAll(result, x => x.ToString()));
            }

            textWriter.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
