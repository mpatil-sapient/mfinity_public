using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSharpPoc.CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            for (Int64 i = 1; i <= 1000; i++)
            {
                squarexplussquarexminusone(i);
                //Console.WriteLine("{0} * {1} = {2}", i, i-1, squarexplussquarexminusone(i));
            }
            stopWatch.Stop();
            Console.WriteLine("time taken " + stopWatch.Elapsed.TotalMilliseconds);
            Console.Read();
        }

        static Int64 square(Int64 x) { return x * x; }

        static Int64 squarexplussquarexminusone(Int64 x) {
            if (x == 1) return square(x);
            else return square(x) + square(x-1);
        }
    }
}
