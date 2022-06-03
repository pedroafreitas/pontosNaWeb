namespace WebScraper.Notes
{   
    class Dog
    {
        public string Name {get; set; }
        public string Race {get; set; }

        public Dog(string Name, string Race)
        {
            this.Name = Name;
            this.Race = Race;
        }

        public void Walk()
        {
            Console.WriteLine("Walk");
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }

        public void Eat()
        {
            Console.WriteLine("Eat");
        }
    }
}