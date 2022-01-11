namespace WebScraper.Notes
{
    class Client
    {
        static void ClientClassForDidaticPorpouses()
        {
            Person person1 = new PersonBuilder().Build();

            Person person2 = new PersonBuilder().SetLastName("Pedro").SetLastName("Freitas").Build();

        }
    }
}