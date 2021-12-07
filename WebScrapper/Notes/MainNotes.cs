using System.Net;
using System.Text.RegularExpressions;

namespace WebScraper.Notes
    {
        public class MainNotes
        {
            static void RunMain()
            {
                //------------Fields and Properties------------

                Person person = new("ssn", "data", "data", "Anna", "Clarinha", 21, 255);

                person.FirstName = "Anna";
                person.LastName = "Vieira";

                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);

                Console.WriteLine(person.HasProperDocuments);

                person.FirstName = "";
                Console.WriteLine(person.FirstName);
            
                //-----------------Inheritance-----------------

                Dog dog1 = new("Toby", "Dachshund");
                dog1.Sleep();

                SuperDog dog2 = new("Alva", "Vira lata");
                dog2.Sleep();
            
                //-----------------Using-----------------
                //client will be disposeble after the using scope
                using (WebClient client = new())
                {
                    string googleMainPage = client.DownloadString("http://www.google.com");
                }
            
                //-----------------Builder Pattern-----------------
                Person person1 = new("ssn", "data", "data", "Anna", "Pinto", 21, 255);

                Person person2 = new("ssn", "data", "data", "Anna", "Vieira", 21, 255);

                Person person3 = new PersonBuilder().Build();

                Person person4 = new PersonBuilder().SetAge(40).Build();

                                //o retorno disso é usado nesse que é usado nesse que é usado nesse (eu acho).
                Person person5 = new PersonBuilder().SetLastName("Freitas").SetFirstName("Pedro").Build();

                //-----------------Single Responsibily-----------------

                SimpleCalculator simpleCalculator = new();
                simpleCalculator.Add(1,2);

                //-----------------Regex-----------------
                MatchCollection matches = Regex.Matches("This is my cat", "This is my [a-z]at");

                foreach(var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }