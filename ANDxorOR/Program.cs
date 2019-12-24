using System;

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

                max = Math.Max(s, max);
            }
            return max;
        }

        static int andXorOr2(int[] a)
        {
            int m1I = 0, m2I = 0;
            int m1 = int.MaxValue, m2 = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < m1)
                {
                    m2 = m1;
                    m1 = a[i];

                    m2I = m1I;
                    m1I = i;

                    if (m2 == int.MaxValue)
                        continue;
                }
                else if (a[i] < m2)
                {
                    m2I = i;
                    m2 = a[i];
                }
                else
                {
                    CalcMax(a[i], m1);

                    for (int j = Math.Max(m1I, m2I) + 1; j < i; j++)
                    {
                        CalcMax(a[i], a[j]);
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

        }


        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int aCount = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int result = andXorOr2(a);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
