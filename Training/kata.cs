using System.Text.RegularExpressions;
using System.Text;

namespace Training
{
    public class Kata
    {
        public string PigIt(string str)
        {
            string first = string.Empty;
            //string[] splitData = s.Split(new string[] { "|", ";" }, StringSplitOptions.RemoveEmptyEntries);
            //var res = Regex.Matches(str, @"([.,!?&;])").Cast<Match>().Select(match => match.Value).ToList();

            for(int i = 0; i < str.Length; ++i)
            {
                
                // if (!str[i].ToString() Matches regex && isFirstLetter(str[i])){
                //     first = str[i];
                //     if(isEndingLetter(str[i])){

                //     }
                // }

                // result.Add(str[int]);
            }

            return str;
        }

        public byte[] AlphabetPosition(string text)
        {
            text = text.ToUpper();
            byte[] ascii = Encoding.ASCII.GetBytes(text);
            List<int> removeIndex = new();

            for (int i = 0; i < ascii.Length; ++i)
            {
                if(ascii[i] > 90 || ascii[i] < 65)
                {
                    removeIndex.Add(i);
                } 
                else 
                {
                    ascii[i] = (byte)(ascii[i] - 64);
                }
            }
            ascii = RemoveIndexesByteArray(ascii, removeIndex);
            return ascii;
            // return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(x => x - 'a'+1));
        }

        public static byte[] RemoveIndexesByteArray(byte[] array, List<int> removeIndexes)
        {
            List<byte> tmp= new List<byte>(array);
            int control = 0;
            for (int i = 0; i < removeIndexes.Count; ++i)
            {
                tmp.RemoveAt(removeIndexes[i]-control); 
                ++control;
            }
            array = tmp.ToArray();
            return array;
        }

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
