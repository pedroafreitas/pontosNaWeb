using System.Text.RegularExpressions;
using System;

namespace Training
{
    public class Kata
    {
        public string Disemvowel(string str)
        {
            string result = str;
            Regex isVowel = new Regex((@"[aeiou]"), RegexOptions.IgnoreCase);
            int j = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if(isVowel.IsMatch(str[i].ToString()))
                {
                    result = result.Remove((i - j),1);
                    ++j;            
                }
            }
            return result;
            //return Regex.Replace(str,"[aeiou]", "", RegexOptions.IgnoreCase);

        }

        public string ToCamelCase(string str)
        {
            string result = string.Empty;
            bool upper = false;
            bool notFirst = false;
            foreach(char c in str)
            {
                if(IsChar(c.ToString()))
                {
                    result = string.Concat(result, upper ? Char.ToUpper(c) : c);
                    upper = false;
                    notFirst = true;
                }
                else 
                {
                    if(notFirst)
                        upper = true;
                }
            }
            return result;
            //return Regex.Replace(str, @"[_-](\w)", m => m.Groups[1].Value.ToUpper());

        }

        public static bool IsChar(string c)
        {
            Regex isChar = new Regex((@"[A-Za-z]"));

            return isChar.IsMatch(c);
        }

    }
}
