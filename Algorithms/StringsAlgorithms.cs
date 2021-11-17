using System.Text;

namespace Algorithms
{
    public class StringsAlgorithms
    {
        public String InvertString(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            { 
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedString = new String(charArray);
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
