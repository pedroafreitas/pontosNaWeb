using System.Text.RegularExpressions;

namespace WebScraper.Builders
{
    class ScrapeCriteriaPartBuilder
    {
        private string _regex;
        private RegexOptions _regexOption;

        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
       }

       public ScrapeCriteriaPartBuilder SetRegex(string regex)
       {
           _regex = regex;
           return this;
       }
    
        public ScrapeCriteriaBuilder SetRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScrapeCriteriaBui
    }
}