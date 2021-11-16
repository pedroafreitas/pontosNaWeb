using System;

namespace SimpleCalculator
{
    class Notes
    {
        public int basicCommands(){

            string input = Console.ReadLine();

            int convertedInputToNumber;
            int.TryParse(input, out convertedInputToNumber);

            int number = 90;
            int result = 10 + 10 - 100 + 100 - number + convertedInputToNumber; 

            Console.WriteLine(result);

            string someText = "meh";
            string otherText = "meh2";

            bool isEqual = someText.Equals(otherText, StringComparison.Ordinal);

            string addedText = someText + " " + otherText + " meh 3";
            string formatedText = string.Format("{0} {1} meh3", someText, otherText);

            Console.WriteLine(formatedText.Length);
            Console.WriteLine(addedText.Length);
            Console.WriteLine(formatedText[3]);

            Console.WriteLine(someText.Substring(0,2));

            Console.WriteLine(someText.ToLower());
            Console.WriteLine(someText.ToUpper());

            string anotherText = string.Empty;

            string replacedText = someText.Replace("h", "lhor emprego do mundo");
            Console.WriteLine(replacedText);

            input = Console.ReadLine();
            string password = Console.ReadLine();

            if (input.Equals("Pedro") && password.Equals("123"))
            {
                Console.WriteLine("nice");
            } else if (input.Equals("Anna") && password.Equals("123"))
            {
                Console.WriteLine("nice");
            }
            else
            {
                return 1;
            }

            switch(input)
            {
                case "Pedro":
                    Console.WriteLine("nice");
                    break;
                case "Anna":
                    Console.WriteLine("nice");
                    break; 
                default:
                    return 1;
            }

            Person person1  = new Person();
            Console.WriteLine(person1.getAge());
            person1.setAge(99);
            Console.WriteLine(person1.getAge());

            Person.greet();

            //Unhandled exception
            //string newText =  "this is some text".Substring(8, 100);
            try
            {
                input = Console.ReadLine();

                try 
                {
                    StringToIntConverter stringToIntConverter = new StringToIntConverter();
                    stringToIntConverter.convert(input);
                } catch (Exception ex) {
                    Console.WriteLine("There was an error with conversion: {0}", ex.Message);
                }
                
            } catch(Exception ex) {
                Console.WriteLine("There was an error: {0}", ex.Message); //this is a lot more generic
            } finally {
                //Finally is used to run a code necessary after try catch.

                //If the code here doesn't support the try catch or if it doesn't free used resources, then
                //it should not been used.
            }
            //It is not a good practice to have code after try catches.
            //You could try do create try catch routes - one inside the other.

            return 0;
        }
    }
}