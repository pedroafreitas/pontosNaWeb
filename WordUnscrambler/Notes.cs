namespace WordUnscrambler
{
    class Notes
    {
        static void Topics(string [] args)
        {
            /*----------======Tópico======----------*/
            //Basic arrays, lists and interators
            List<int> myList = new List<int>();
            myList.Add(10);
            myList.Add(1);

            Console.WriteLine(myList.Count());

            int[] a1 = new int[100];
            a1[10] = 4;

            var l1 = new List<int>() {1,3,3,2,23,3,2};
            var l2 = new List<int>();

            int[] a2 = {1,2,3,4,2,4};
            Array.Sort(a2);

            int[] a3 = {1,3,4,2,6,7};
            foreach (var element in a3)
            {
                Console.WriteLine(element);
            }
            for(int i = 0; i < a3.Length; i++)
            {
                Console.WriteLine(a3[i]);
            }

            int index = 0;
            while(index < a3.Length)
            {
                Console.WriteLine(a3[index]);
                index++;
            }
        
            /*----------======Tópico======----------*/
            //Referência e value types
            int a = 10;
            ChangeNumber(a);

            Person newPerson = null;

            Person person = newPerson ?? new Person("Anna", "Clara"); //if newPerson is null do new Person("Anna", "Clara");

            ChangeName(person);

            int b = 10;
            ChangeNumber2(ref b); //We can also use out

            /*
            =>There is a way to force value types to behave as ref types: out e ref
            out doen't need to a initialized variable
            out requires change before exits the method
            */
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);

            
            /*----------======Tópico======----------*/
            //System.IO
            string [] lines= {"Olha que coisa", "Mais linda", "Mais Incrível"};
            File.WriteAllLines("MyFirstFile.txt", lines);

            string[] fileContent = File.ReadAllLines("MyFirstFile.txt");

            //If the file is large, it's better to interate over it.
            foreach (string line in File.ReadLines("MyFirstFile.txt"))
            {
                Console.WriteLine(line);
            }

            /*----------======Tópico======----------*/
            //DRY
            //In this situation the better solution is to create a method.
            //Notice that we repeat the same operation twice.
            string[] linesDry = {"primeiro", "segundo", "terceiro"};
            formatLines(linesDry);
            File.WriteAllLines("FormattedFile.txt", formatLines(linesDry));
            

            string[] otherLines = {"first", "second", "third"};
            File.WriteAllLines("AnotherFormattedFile.txt", formatLines(otherLines));

        }

        static string[] formatLines(string[] unformattedLines)
        {
            int strLength = unformattedLines.Length;
            string[] formattedLines = new string[strLength];

            for(int i = 0; i < strLength; i++)
            {
                formattedLines[i] = String.Format("{0} {1} {2}", "===>", unformattedLines[i], "<===");
            }
            return formattedLines;
        }
        /*----------======Tópico======----------*/
        //Readonly vs. Constant
        //conts is static and only accepts basic types
        //Se o valor ele NUNCA vai mudar -> const
        //Se o valor ele pode mudar, mas é imutável durante a excecução -> readonly
        public const string someText = "This is text";
        public readonly string otherText = "this is other text";


        static void ChangeNumber2(ref int b) //We can also use out
        {
            b = 90;
        }

        static void ChangeNumber(int a)
        {
            /*Neste caso o valor de a é perdido logo 
            depois das variáveis da função sairem da 
            pilha de chamada(call stack).*/
            a = 90; 
        }
        static void ChangeName(Person personToChange)
        {
            /*Aqui, os objetos apontam para o mesmo local.
            Tanto personToChange, como person (na Main).
            Ambos são value types se forem struct.*/
            personToChange.FirstName = "John";
            personToChange.LastName = "Smith";
        }
    }
}