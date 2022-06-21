using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Calculating the sum of 2 numbers.");
            string result = Sum(2, 4).ToString();
            Console.WriteLine("Sum of numbers:- {0} ", result);
            Console.ReadLine();
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
