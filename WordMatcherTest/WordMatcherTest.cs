using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Test.Unit;
[TestClass]
public class WordMatcherTest
{
    private readonly WordMatcher _wordMartcher = new();
    [TestMethod]
    public void ScrambledWordMatchesGivenWordInTheList1()
    {
        string[] words = {"cat", "char", "more"};
        string [] scrambledWords = {"omre"};
        var matchedWords = _wordMartcher.Match(scrambledWords, words);

        Assert.IsTrue(matchedWords.Count == 1);
        Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
        Assert.IsTrue(matchedWords[0].Word.Equals("more"));
    }

    [TestMethod]
    public void ScrambledWordMatchesGivenWordInTheList2()
    {
        string[] words = {"cat", "char", "hey", "tac"};
        string[] scrambledWords = {"cta", "yeh"};
        var matchedWords = _wordMartcher.Match(scrambledWords, words);

        Assert.IsTrue(matchedWords.Count == 3);
        Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("cta"));
        Assert.IsTrue(matchedWords[2].Word.Equals("hey"));
    }
}


