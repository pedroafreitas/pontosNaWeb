namespace WordUnscrambler.Data
{
    //Using struct because we are characterazing variables
    struct MatchedWord
    {
        public string ScrambledWord { get; set; }
        public string Word { get; set;}
    }
}