using System.Net;
using System.Text.RegularExpressions;
using WebScraper.Builders;
using WebScraper.Data;
using WebScraper.Notes;
using WebScraper.Workers;

namespace WebScraper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Insira a cidade para obter informações: ");
                var craigslistCity = Console.ReadLine() ?? string.Empty;


                Console.WriteLine("Insira a categoria de busca");
                var craigslistCategoryName = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"https://{craigslistCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craigslistCategoryName}");
                
                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex("<a href=\"(.*?)\" data-id=\"(.*?)\" class=\"(.*?)\" id=\"(.*?)\">(.*?)<\\/a>")
                        .WithRegexOption(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(">(.*?)<\\/a>")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex("href=\"(.*?)\"")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if(scrapedElements.Any())
                    {
                        foreach(var scrapedElement in scrapedElements) Console.WriteLine(scrapedElement);
                    }
                    else
                    {
                        Console.WriteLine("Não encontrado");
                    }
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}