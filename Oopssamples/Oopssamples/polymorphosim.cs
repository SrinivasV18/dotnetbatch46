using System;
namespace Oopssamples
{
    //Base Class
    public class Father
    {
        public void FatherMethod()
        {
            Console.WriteLine("this property belong to Father");
        }
    }

    //Derived class
    public class Child : Father
    {
        public void ChildMethod()
        {
            Console.WriteLine("this property belong to Child");
        }
    }
    class Inheritance
    {
        //Entry point
        static void Main(string[] args)
        {

            Father fObj = new Father();
            fObj.FatherMethod();

            //Here Child object can access both class methods
            Child cObj = new Child();
            cObj.FatherMethod();
            cObj.ChildMethod();
            
            
        }
    }
}