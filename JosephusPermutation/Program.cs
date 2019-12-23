using System;
using System.Collections.Generic;

namespace JosephusPermutation
{
    class Program
    {
        //0 2->1 4->3 6->5 8
        //[1,2,3,4,5,6,7] - initial sequence
        //[1, 2, 4, 5, 6, 7] => 3 is counted out and goes into the result[3]
        //[1, 2, 4, 5, 7] => 6 is counted out and goes into the result[3, 6]
        //[1, 4, 5, 7] => 2 is counted out and goes into the result[3, 6, 2]
        //[1, 4, 5] => 7 is counted out and goes into the result[3, 6, 2, 7]
        //[1, 4] => 5 is counted out and goes into the result[3, 6, 2, 7, 5]
        //[4] => 1 is counted out and goes into the result[3, 6, 2, 7, 5, 1]
        //[] => 4 is counted out and goes into the result[3, 6, 2, 7, 5, 1, 4]

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //JosephusPermutation3(new List<object> { 1, 2, 3, 4, 5, 6, 7 }, 3);
            //JosephusPermutation2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1);
            //JosephusPermutation2(new object[] { true, false, true, false, true, false, true, false, true }, 9);

            JosephusPermutation3(new List<object> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 }, 11);
        }

        static int[] JosephusPermutation(int[] seq, int k)
        {
            var ret = new int[seq.Length];

            int i = 0; int j = i;
            while (i < seq.Length)
            {
                ret[i] = seq[(((i + 1) * k) - 1) % (seq.Length - i)];
                i++;// i += k;
            }

            return ret;
        }

        static List<object> JosephusPermutation2(List<object> items, int k)
        {
            var ret = new List<object>();

            int j = -1;

            while (ret.Count < items.Count)
            {
                for (int a = 0; a < k; a++)
                {
                    j++;
                    if (items[j % items.Count] == null)
                        a--;
                }

                ret.Add(items[j % items.Count]);
                items[j % items.Count] = null;
            }

            return ret;
        }

        static List<object> JosephusPermutation3(List<object> items, int k)
        {
            var ret = new List<object>();
            var length = items.Count;
            int j = -1;

            while (ret.Count < length)
            {
                j += k;
                if (j % items.Count == 0) j--;

                ret.Add(items[j % items.Count]);
                items.RemoveAt(j % items.Count);

                j--;
            }

            return ret;
        }
    }
}
