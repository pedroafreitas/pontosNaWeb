using System;
using System.Text.RegularExpressions;
using Training;

class Program
{
    static void Main(string[] args)
    {
        string[] str = {"bla@gmail.com", "blo@gmail.com", "@gmail.com"};

        foreach(string s in str)
        {
            //Console.WriteLine("{0} {1} a valid email", s, IsValidEmail(s) ? "is" : "is not");
        }

        string kataStr = "Hello World !";

        Kata kata = new();

        string returnString = string.Join(" ",kata.PigIt(kataStr));
        Console.WriteLine(returnString);
    }
    
    public static bool IsValidEmail(string inputEmail)
    {
        string strRegex = @"[A-Z]* \@gmail.com?";

        Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

        return re.IsMatch(inputEmail);
    }
}