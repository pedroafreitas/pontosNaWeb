using System.Text.RegularExpressions;
using WebScraper.Data;

namespace WebScraper.Workers
{
    class Scraper
    {
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<string> scrapedElements = new List<string>();
            
            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            //First level of the element
            foreach(Match match in matches)
            {
                if(!scrapeCriteria.Parts.Any())
                {
                    scrapedElements.Add(match.Groups[0].Value);
                } 
                else 
                {
                    //Second level of the element
                    foreach(var part in scrapeCriteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);

                        if(matchedPart.Success) scrapedElements.Add(matchedPart.Groups[1].Value);
                    }
                }
            }
            return scrapedElements;
        }
    }
}