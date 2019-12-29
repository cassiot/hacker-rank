using System;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        struct PumpInfo
        {
            public int position;
            public int fuel;
            public int nextPumpDistance;
        }

        static int truckTour(int[][] petrolpumps)
        {
            int totalFuel = 0;
            var q = new Queue<PumpInfo>();
            int i = 0, d = 0;

            while (q.Count != petrolpumps.Length)
            {
                var np = petrolpumps[i];

                while (totalFuel - d < 0 && q.Count > 0)
                {
                    var dq = q.Dequeue();
                    totalFuel -= dq.fuel;
                    totalFuel += dq.nextPumpDistance;
                }

                totalFuel -= d;

                q.Enqueue(new PumpInfo() { fuel = np[0], nextPumpDistance = np[1], position = i });
                totalFuel += np[0];
                d = np[1];

                i++;
                i %= petrolpumps.Length;
            }

            return q.Peek().position;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[][] petrolpumps = new int[n][];

            for (int petrolpumpsRowItr = 0; petrolpumpsRowItr < n; petrolpumpsRowItr++)
            {
                petrolpumps[petrolpumpsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp));
            }

            int result = truckTour(petrolpumps);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
