using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            string b = null;
            for (bool exit = false; exit == false;)
            {
                Console.WriteLine("Enter the first number, it will be stored as double: ");
                exit = Double.TryParse(Console.ReadLine(), out a);
                if (!exit)
                {
                    Console.WriteLine("Something went wrong");
                }
                Console.In.ReadLine();
            }
            for (bool exit = false; exit == false;)
            {
                double buffer;
                Console.WriteLine("Enter the second number, it will be stored as string: ");
                b = Console.ReadLine();
                exit = Double.TryParse(b, out buffer);
                if (!exit)
                {
                    Console.WriteLine("Something went wrong");
                }
                Console.In.ReadLine();
            }
            Rational r = new Rational();
            r.Set(a);
            Rational t = new Rational();
            t.Set(b);
            Console.WriteLine("First: ", r);
            Console.WriteLine("Second: ", t);
            Console.WriteLine("Sum: ", r + t);
            Console.WriteLine("Multiplication: ", r * t);
            Console.WriteLine("Equal? ", r == t);
            Console.WriteLine("First is bigger? ", r > t);
            Console.ReadKey();
        }
    }
}
