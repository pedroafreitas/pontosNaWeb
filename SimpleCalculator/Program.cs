 using System;

namespace SimpleCalculator
{
    class Program
    {
        static int Main(string[] args)
        {
            string input = Console.ReadLine();

            int convertedInputToNumber;
            int.TryParse(input, out convertedInputToNumber);

            int number = 90;
            int result = 10 + 10 - 100 + 100 - number + convertedInputToNumber; 

            Console.WriteLine(result);

            return 0;
        }
    }
}