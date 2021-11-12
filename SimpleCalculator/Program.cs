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

            string someText = "meh";
            string otherText = "meh2";

            bool isEqual = someText.Equals(otherText, StringComparison.Ordinal);

            string addedText = someText + " " + otherText + " meh 3";
            string formatedText = string.Format("{0} {1} meh3", someText, otherText);

            Console.WriteLine(formatedText.Length);
            Console.WriteLine(addedText.Length);
            Console.WriteLine(formatedText[3]);

            Console.WriteLine(someText.Substring(0,2));

            Console.WriteLine(someText.ToLower());
            Console.WriteLine(someText.ToUpper());

            string anotherText = string.Empty;

            string replacedText = someText.Replace("h", "lhor emprego do mundo");
            Console.WriteLine(replacedText);

            input = Console.ReadLine();
            string password = Console.ReadLine();

            if (input.Equals("Pedro") && password.Equals("123"))
            {
                Console.WriteLine("nice");
            } else if (input.Equals("Anna") && password.Equals("123"))
            {
                Console.WriteLine("nice");
            }
            else
            {
                return 1;
            }

            switch(input)
            {
                case "Pedro":
                    Console.WriteLine("nice");
                    break;
                case "Anna":
                    Console.WriteLine("nice");
                    break; 
                default:
                    return 1;
            }
            return 0;
        }
    }
}