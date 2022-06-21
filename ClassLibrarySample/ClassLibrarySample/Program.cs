using System;
using ClassLibrary1;

namespace ClassLibrarySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMath myMath = new MyMath();
            Console.WriteLine("Sum :- " + myMath.Sum(3,5).ToString());
            Console.WriteLine("Diff :- " + myMath.Diff(5, 2).ToString());
            Console.WriteLine("Multiply :- " + myMath.Multiply(3, 5).ToString());
        }
    }
}
