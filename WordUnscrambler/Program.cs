using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();   

        static void Main(string[] args)
        {
            bool continueProgram = true;

            do
            {
                Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case Constants.File:
                        Console.Write(Constants.EnterScrambledWordsViaFile);
                        ScrambleWordsInFileScenario();
                        break;
                    case Constants.Manual:
                        Console.Write(Constants.EnterScrambledWordsManually);
                        ScrambleWordsManualScenario();
                        break;
                    default:
                        Console.WriteLine(Constants.EnterScrambleWordsNotRecognize);
                        break;
                }

                var continueDecision = string.Empty;
                do{

                    Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while(
                !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                continueProgram = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                
            }while(continueProgram);
        }

        private static void ScrambleWordsInFileScenario()
        {
            try{
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
            
        }

        private static void ScrambleWordsManualScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordlist = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordlist);

            if (matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            } 
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }

        }
    }   
}