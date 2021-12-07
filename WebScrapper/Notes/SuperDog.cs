using System;
using WebScraper.Notes;

namespace WebScraper
{
    class SuperDog : Dog
    {
        public SuperDog(string Name, string Race) : base(Name, Race)
        {

        }

        public void Fly()
        {
            Console.WriteLine("eu to voando");
        }
    }
}