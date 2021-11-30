using System.Text.RegularExpressions;
using System.Text;

namespace CodeWars
{
    public class Kata
    {
        
        /*
        Passo 1: fazer split das palavras e salvar numa lista
        Passo 2: verificar se é pontuação
        Passo 3: Cocatenar primeira letra no final
        Passo 4: Concatenar ay no final 
        Passo 5: Concatenar todas as palavras na lista para retorno
        */
        public string PigIt(string str)
        {
            string[] tokens = str.Split();
            for(int i = 0; i < tokens.Length; ++i)
            {
                if(!IsPunctuation(tokens[i]))
                    tokens[i] = string.Concat(tokens[i], tokens[i][0], "ay").Remove(0, 1);
            }
                        
            return string.Join(" ", tokens);
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

        public static bool IsPunctuation(string str)
        {
            Regex isPonctuation = new Regex((@"[^ (\w)]"));

            return isPonctuation.IsMatch(str);
        }

        public static bool IsChar(string str)
        {
            Regex isChar = new Regex((@"[A-Za-z]"));

            return isChar.IsMatch(str);
        }

    }
}
