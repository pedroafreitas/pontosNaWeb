namespace WordUnscrambler.Data
{
    //Using struct because we are characterazing variables
    public struct MatchedWord
    {
        public string ScrambledWord { get; set; }
        public string Word { get; set;}
    }
}