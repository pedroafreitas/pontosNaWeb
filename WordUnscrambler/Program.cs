
namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continue = true;

            do
            {
                Console.WriteLine("Options: F for file, M for Manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter file name: ");
                        ScrambleWordsInFileScenario();
                        break;
                    case "M":
                        Console.Write("Enter words: ");
                        ScrambleWordsManualScenario();
                        break;
                    default:
                        break;
                }
            }while();
        }

        private static void ScrambleWordsInFileScenario()
        {
            throw new NotImplementedException();
        }

        private static void ScrambleWordsManualScenario()
        {
            throw new NotImplementedException();
        }
    }   
}