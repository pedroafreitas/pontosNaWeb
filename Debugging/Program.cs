using System;
using System.Diagnostics;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Fibonacci(5);
            Fibonacci(1);
            Console.WriteLine(result);
            Console.ReadKey(true);

            int count = 0;

            Console.WriteLine("This message is readable by the end user.");
            Trace.WriteLine("This is a trace message when tracing the app.");
            Debug.WriteLine("This is a debug message just for developers.");
            Debug.WriteLineIf(count == 0, "The count is 0 and this may cause an exception.");

            bool errorFlag = false;
            System.Diagnostics.Trace.WriteIf(errorFlag, "Error");

            Console.WriteLine(IntegerDivideCheck(10, 2));
            Console.WriteLine(IntegerDivideCheck(10, 0));
        }
        static int IntegerDivideCheck(int dividend, int divisor)
        {
            Debug.Assert(divisor != 0, $"{nameof(divisor)} is 0 and will cause exception");
            return dividend/divisor;
        }
        static int Fibonacci(int n)
        {
            Debug.Assert(n > 0, "The input value (n) must be bigger than zero(0).");
            Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
            Debug.WriteLine($"We are looking for the {n}th number");

            int n1 = 0;
            int n2 = 1;
            int sum = 0;

            for(int i = 1; i < n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
            }
            return n == 0 ? n1 : n2;
        }
    }
}