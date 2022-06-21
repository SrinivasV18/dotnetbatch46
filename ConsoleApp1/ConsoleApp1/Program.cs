using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            int s1, s2;
            s1 = Convert.ToInt32(Console.ReadLine());
            s2 = Convert.ToInt32(Console.ReadLine());
            int res= Sum(s1, s2);
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
    }
}
