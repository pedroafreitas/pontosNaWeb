using System;

namespace SimpleCalculator
{
    public class Person
    {
        //Non static methods can only be created if we create an object of that method.
        private int _age = 25;
        public int getAge()
        {
            return _age;
        }

        public void setAge(int newAge)
        {
            _age = newAge;
        }

        static public void greet(){
            Console.WriteLine("STATIC SHOCK");
        }

    }
}