using System;
using System.Collections.Generic;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var qLen = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
            long lastMax = 0;
            var l = new List<long>();

            for (int i = 0; i < qLen; i++)
            {
                var line = Console.ReadLine();
                var split = line.Split(" ".ToCharArray());

                if (split[0] == "1")
                {
                    var v = long.Parse(split[1]);
                    stack.Push(v);
                    if (v > lastMax && lastMax != -1) lastMax = v;
                }
                else if (split[0] == "2")
                {
                    var v = stack.Pop();
                    if (v == lastMax) lastMax = -1;
                }
                else
                {
                    if (lastMax == -1)
                    {
                        foreach (var v in stack)
                        {
                            if (v > lastMax) lastMax = v;
                        }
                    }
                    l.Add(lastMax);
                }
            }

            foreach (var i in l)
                Console.WriteLine(i);
        }
    }
}
