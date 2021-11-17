namespace WordUnscrambler
{
    class Program
    {
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
            throw new NotImplementedException();
        }

        private static void ScrambleWordsManualScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string [] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }
    }   
}