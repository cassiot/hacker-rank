using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var sb = new StringBuilder();
            var stack = new Stack<string>();
            
            for (int i = 0; i < n; i++)
            {
                var c = Console.ReadLine();
                var sp = c.Split(' ');

                switch (sp[0])
                {
                    case "1":
                        sb.Append(sp[1]);
                        stack.Push(c);
                        break;
                    case "2":
                        var q = int.Parse(sp[1]);
                        var t = sb.ToString().Substring(sb.Length - q, q);
                        sb.Remove(sb.Length - q , q);
                        stack.Push("2 " + t);
                        break;
                    case "3":
                        Console.WriteLine(sb[int.Parse(sp[1]) - 1].ToString());
                        break;
                    case "4":
                        var csp = stack.Pop().Split(' ');

                        if (csp[0] == "1")
                        {
                            var cq = csp[1].Length; 
                            sb.Remove(sb.Length - cq, cq);
                        }
                        else
                            sb.Append(csp[1]);

                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
