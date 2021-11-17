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

        public string InverstOrderOfWords(string str)
        {
            
            return str;
        }
    }


}
