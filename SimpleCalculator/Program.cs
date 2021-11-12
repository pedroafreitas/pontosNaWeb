 using System;

namespace SimpleCalculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Notes notes = new Notes();
            // notes.basicCommands();

            try
            {
                //first write the placeholders
                InputConverter inputConverter = new InputConverter();
                CalcEngine calcEngine = new CalcEngine();
                int op = 1;
                while(op == 1)
                {

                    double firstNumber = inputConverter.ConvertToNumeric(Console.ReadLine());
                    string operation = Console.ReadLine();
                    double secondNumber = inputConverter.ConvertToNumeric(Console.ReadLine());

                    double result = calcEngine.Calc(operation, firstNumber, secondNumber);
                    
                    Console.WriteLine("Result: {0}\n Do want to perform another operation? Yes(1) No(0)", result);

                    int.TryParse(Console.ReadLine(), out op);
                }


            } catch (Exception ex)
            {
                //In the real world we would want to log the message
                Console.WriteLine(ex.Message);
                
            }
            
        }
    }
}