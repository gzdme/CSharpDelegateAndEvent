using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Action action = new Action(calculator.Report);

            Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);

            int a = 100;
            int b = 200;
            int z = 0;

            action.Invoke();
            //z = func1.Invoke(a, b);
            z = func1(a, b);
            Console.WriteLine(z);
            //z = func2.Invoke(a, b);
            z = func2(a, b);
            Console.WriteLine(z);
            //Console.ReadKey();
        }
    }
    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods.");
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }
        public int Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }
        //public int Add(int a, int b)
        //{
        //    int result = a + b;
        //    return result;
        //}
    }
}
