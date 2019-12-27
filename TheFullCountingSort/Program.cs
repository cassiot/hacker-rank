using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheFullCountingSort
{
    class Program
    {
        static void countSort(List<List<string>> arr)
        {
            for (int i = 0; i < arr.Count / 2; i++)
                arr[i][1] = "-";

            bool changed = true;
            int k = 0;
            int sp = arr.Count;
            int lk = arr.Count;

            while (changed || k < arr.Count)
            {
                var c = int.Parse(arr[k][0]);
                var n = int.Parse(arr[k + 1][0]);

                if (c > n)
                {
                    var temp = arr[k];
                    arr[k] = arr[k + 1];
                    arr[k + 1] = temp;
                    lk = k + 1;
                    changed = true;
                }

                k++;

                if (k + 1 == sp)
                {
                    if (!changed)
                        break;

                    sp = lk;
                    k = 0;
                    changed = false;
                }
            }

            for (int i = 0; i < arr.Count; i++)
                Console.Write($"{arr[i][1]} ");
        }

        static void countSort2(List<List<string>> arr)
        {
            int max = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if(i < arr.Count / 2)
                    arr[i][1] = "-";

                max = Math.Max(max, int.Parse(arr[i][0]));
            }
            
            max++;
            var sbList = new StringBuilder[max];

            for (int i = 0; i < arr.Count; i++)
            {
                var b = int.Parse(arr[i][0]);

                if (sbList[b] == null)
                    sbList[b] = new StringBuilder();

                sbList[b].Append(arr[i][1]).Append(" ");
            }

            for (int i = 0; i < max; i++)
                Console.Write($"{sbList[i]}");
        }

        public void Print(List<List<string>> arr)
        {
            for (int i = 0; i < arr.Count; i++)
                Console.Write($"{arr[i][1]} ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }

            countSort2(arr);
        }
    }
}
