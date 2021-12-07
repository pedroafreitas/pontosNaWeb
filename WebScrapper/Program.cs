using System.Net;
using WebScraper.Notes;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Fields and Properties------------");

            Person person = new("ssn", "data", "data", "Anna", "Clarinha", 21, 255);

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
        
            Console.WriteLine("-----------------Using-----------------");
            //client will be disposeble after the using scope
            using (WebClient client = new WebClient())
            {
                string googleMainPage = client.DownloadString("http://www.google.com");
                Console.WriteLine(googleMainPage);
            }
        
            Console.WriteLine("-----------------Builder Pattern-----------------");
            Person person1 = new("ssn", "data", "data", "Anna", "Pinto", 21, 255);

            Person person2 = new("ssn", "data", "data", "Anna", "Vieira", 21, 255);

            Person person3 = new PersonBuilder().Build();

            Person person4 = new PersonBuilder().SetAge(40).Build();

                            //o retorno disso é usado nesse que é usado nesse que é usado nesse (eu acho).
            Person person5 = new PersonBuilder().SetLastName("Freitas").SetFirstName("Pedro").Build();
        }
    }

}