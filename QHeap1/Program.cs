using System;
using System.Collections.Generic;

namespace QHeap1
{
    class Program
    {
        static void Main(string[] args)
        {
            var qLen = int.Parse(Console.ReadLine());
            
            var list = new SortedList<long, long>();

            for (int i = 0; i < qLen; i++)
            {
                var line = Console.ReadLine();
                var split = line.Split(" ".ToCharArray());

                if (split[0] == "1")
                    list.Add(long.Parse(split[1]), long.Parse(split[1]));
                else if (split[0] == "2")
                    list.Remove(long.Parse(split[1]));
                else
                    Console.WriteLine(list.Keys[0]);
            }
        }
    }
}
