using System.Text;

namespace Algorithms
{
    public class StringsAlgorithms
    {
        #region ValidationAlgorithms
        public bool IsUpperCase(string s)
            => s.All(char.IsUpper);

        public bool IsLowerCase(string s)
            => s.All(char.IsLower);

        public bool IsPasswordComplex(string s)
            => s.Any(char.IsUpper) 
            && s.Any(char.IsLower) 
            && s.Any(char.IsDigit);

        public string NormalizeString(string s)
            => s.ToLower().Trim().Replace(",", "");
        
        public bool IsAtEvenIndex(string s, char c, bool caseSensitive = false)
        {
            if(!string.IsNullOrEmpty(s))
            {
                if(caseSensitive)
                {
                    s = s.ToLower();
                    c = char.ToLower(c);
                }

                for(int i = 0; i < s.Length / 2 + 1; i = i+2)
                {
                    if (s[i] == c)
                        return true;
                }
            }
            return false;
        }
        #endregion

        public string InvertString(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            { 
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedString = new(charArray);
            return reversedString;
        }

        public bool CheckPalindrome(string str)
        {
            string invertedStr = InvertString(str);
            if (invertedStr.Equals(str))
            {
                return true;
            }
            return false;
        }

        public string InvertOrderOfWords(string str)
        {

            string aux = string.Empty;
            StringBuilder inverted = new();
            for (int i = str.Length - 1; i >= 0; i--)
            {    
                if(str[i] != ' '){
                    aux += str[i]; 
                } else {
                    inverted.Append(InvertString(aux));
                    inverted.Append(" ");  
                    aux = string.Empty;
                }                
            }

            if (!string.IsNullOrEmpty(aux))
                inverted.Append(InvertString(aux));

            return inverted.ToString();
        }

        public string InvertPhrase(string str)
        {
            string aux = string.Empty;
            StringBuilder inverted = new();

            for (int i = str.Length - 1; i >= 0; i--)
            {    
                if(str[i] != ' '){
                    aux += str[i]; 
                } else {
                    inverted.Append(aux);
                    inverted.Append(" ");  
                    aux = string.Empty;
                }                
            }
            if (!string.IsNullOrEmpty(aux))
                inverted.Append(InvertString(aux));

            return inverted.ToString();
        }
    }


}
