using System;
using System.Collections.Generic;

namespace QueueUsingTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            int aCount = Convert.ToInt32(Console.ReadLine());

            var s1 = new Stack<string>();
            var s2 = new Stack<string>();

            Stack<string> sTemp;
            string peek = null;

            for (int i = 0; i < aCount; i++)
            {
                var line = Console.ReadLine();
                var split = line.Split();

                if (split[0] == "1")
                    s1.Push(split[1]);
                else if (split[0] == "2")
                {
                    if (s2.Count > 0)
                    {
                        s2.Pop();
                    }
                    else
                    {
                        while (s1.Count > 1)
                            s2.Push(s1.Pop());

                        s1.Pop();
                    }
                }
                else
                {
                    if (s2.Count == 0)
                    {
                        while (s1.Count > 0)
                            s2.Push(s1.Pop());
                    }
                    Console.WriteLine(s2.Peek());
                }
            }
        }
    }
}
