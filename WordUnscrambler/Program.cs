using System.IO;
namespace WordUnscrambler
{
    class Program
    {
        private const string wordListFile = "wordlist.txt";
        static void Main(string[] args)
        {
            bool continueProgram = true;

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

                var continueDecision = string.Empty;
                do{

                    Console.WriteLine("Do you want to continue (y/n)?");
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while(
                !continueDecision.Equals("y", StringComparison.OrdinalIgnoreCase) &&
                !continueDecision.Equals("n", StringComparison.OrdinalIgnoreCase));

                continueProgram = continueDecision.Equals("y", StringComparison.OrdinalIgnoreCase);
                
            }while(continueProgram);
        }

        private static void ScrambleWordsInFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ScrambleWordsManualScenario()
        {
            var manuealInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordlist = _fileRead.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordlist);

            if (matchedWords.Any())
            {
                foreach(var word in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1} ", matchedWords.ScreambledWord, matchedWord);
                }
            } 
            else
            {
                Console.WriteLine("No matches have been found.");
            }

        }
    }   
}