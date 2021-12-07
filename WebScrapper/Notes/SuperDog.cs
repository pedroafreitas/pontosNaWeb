using System;
using WebScraper.Notes;

namespace WebScraper
{
    class SuperDog : Dog
    {
                                                    //Use the dog base to construct name and race
        public SuperDog(string Name, string Race) : base(Name, Race)
        {

        }

        public void Fly()
        {
            Console.WriteLine("eu to voando");
        }
    }
}