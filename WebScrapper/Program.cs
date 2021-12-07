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
        
            Console.WriteLine("-----------------Inheritance-----------------");

            Dog dog1 = new("Toby", "Dachshund");
            dog1.Sleep();

            SuperDog dog2 = new("Alva", "Vira lata");
            dog2.Sleep();
        
            Console.WriteLine("-----------------Encapsulation-----------------");
            
        
        }
    }
}