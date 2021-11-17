using System;

namespace WordUnscrambler
{
    //Used to put variables together. A lot simpler.
    class Person
    {
        public Person(string argFirstName, string argLastName)
        {
            FirstName = argFirstName;
            LastName = argLastName;    
        }
        public string FirstName{get; set;}
        public string LastName{get; set;}
    }
}