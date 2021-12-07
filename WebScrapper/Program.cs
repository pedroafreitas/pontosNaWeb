using WebScraper.Notes;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Fields and Properties------------");

            Person person = new("ssn", "data", "data");

            person.FirstName = "Anna";
            person.LastName = "Vieira";

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);

            Console.WriteLine(person.HasProperDocuments);

            person.FirstName = "";
            Console.WriteLine(person.FirstName);
        
            Console.WriteLine("-----------------OOP-----------------");

            Dog dog = new("Toby", "Anna");
            dog.Sleep();
        }
    }
}