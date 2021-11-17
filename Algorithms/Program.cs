using System;

namespace Algorithms
{
    public class Program{

        public static void Main(string[] args)
        {

            StringsAlgorithms strObj = new();
            string input ="Anna Clara Vieira";

            string invertedString = strObj.InvertString(input);
            Console.WriteLine(invertedString);

            if(strObj.CheckPalindrome(input))
            {
                Console.WriteLine("Palindrome");
            }

            Console.WriteLine(strObj.InvertOrderOfWords(input));
        }
    }
}
