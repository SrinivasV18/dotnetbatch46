using System;
namespace Oopssamples
{
    public class Employee
    {
        // Member Variables
        public int empid;
        public string Name;
        public string Address ;

        //constuctor for initializing fields
        public Employee()
        {
            empid = 1101;
            Name = "AAA";
            Address = "Hyderabad";
        }

        public void Display()
        {
            Console.WriteLine("Emp id -" + empid);
            Console.WriteLine("Name -" + Name);
            Console.WriteLine("Address -" + Address);
            Console.WriteLine("Level -" + Level.Medium);
        }
        //public void Display(int eno)
        //{
        //    empid = eno;
        //    Console.WriteLine("Emp id -" + empid);
        //    Console.WriteLine("Name -" + Name);
        //    Console.WriteLine("Address -" + Address);
        //    Console.WriteLine("Level -" + Level.Medium);
        //}
    }
    public class VEmployee : Employee
    {
        int vempid;
        public void Display(int vempid)
        {
            empid = vempid;
            Console.WriteLine("V Emp id -" + vempid);
            base.Display();
        }
    }
    public static class Helper
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public enum Level
    { 
        Low,
        Medium,
        High,
    }
    class MyClass
    {
        
        //method for displaying customer records (functionality)
        //static void Main(string[] args)
        //{
        //    Employee emp = new Employee();
        //    emp.Name = "BBB";
        //    emp.Display();
        //    VEmployee emp1 = new VEmployee();
        //    emp1.Display(23);
        //    Console.WriteLine("Static Method call - " + Helper.Sum(2, 3));
        //}
    }
        // Code for entry point
}