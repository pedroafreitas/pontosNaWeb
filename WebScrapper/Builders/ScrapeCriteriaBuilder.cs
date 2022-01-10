using System.Text.RegularExpressions;
using WebScraper.Data;

namespace WebScraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        private string? _data;
        private string? _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart> _parts;
        
        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
        }   

        public ScrapeCriteriaBuilder SetData(string data)
        {
            _data = data;
            return this;
        }

        public ScrapeCriteriaBuilder SetRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaBuilder SetRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScrapeCriteriaBuilder SetPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts.Add(scrapeCriteriaPart);
            return this;
        }

        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOption;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
    }
}