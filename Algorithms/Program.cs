using System;

namespace Algorithms
{
    public class Program{

        public static void Main(string[] args)
        {

            StringsAlgorithms strObj = new();
            string input = Console.ReadLine();

            string invertedString = strObj.InvertString(input);
            Console.WriteLine(invertedString);

            if(strObj.CheckPalindrome(input))
            {
                Console.WriteLine("Palindrome");
            }
        }
    }
}
