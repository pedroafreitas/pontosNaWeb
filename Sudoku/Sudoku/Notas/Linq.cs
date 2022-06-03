using System;
using System.Linq;

namespace Sudoku.Notas
{
    public class Linq
    {
        static public void LinqLesson()
        {
            //Language integrated query
            Hobbie[] hobbies =
            {
                new Hobbie(1,
                    "Walking"),
                new Hobbie(2,
                    "Swimming"),
                new Hobbie(3,
                    "Bodybuilding")
            };

            var hobbie = hobbies.Where(h => h.Id > 1);
            hobbie.Select(h => h.Name).ToList().ForEach(Console.WriteLine);

            hobbie = hobbies.Where(h => h.Name.Equals("Walking"));
            Console.WriteLine(String.Join(",", hobbie.Select(h => h.Id)));

            var anotherHobbie = hobbies.Where(h => h.Name.Equals("Bodybuilding")).Select(h => h.Id);
            anotherHobbie.ToList().ForEach(Console.WriteLine);

            Console.WriteLine(String.Join(",", anotherHobbie));

            //Tell me the collection and alias (from).
            //Then the condition after where (where).
            //Finally what you want to select from the collected (select).
            hobbie = from h in hobbies where h.Name.Equals("Walking") select h;
            Console.WriteLine(String.Join(", ", hobbie.Select(h => h.Id)));

            var everyHobbieExeceptFirstOne = hobbies.Skip(1);
            Console.WriteLine(String.Join(", ", everyHobbieExeceptFirstOne.Select(h => h.Name)));
        }

        class Hobbie
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Hobbie(int id,
                string name)
            {
                Id = id;
                Name = name;
            }
        }
    }
}