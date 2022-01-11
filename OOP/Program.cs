using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            CarSalesman steveTheSalesman = new("Steve", "Rogers", 1);
            steveTheSalesman.Sell();
            Console.WriteLine(steveTheSalesman.FullName);

            RetailSalesPerson erickTheSalesDude = new("Erick", "Erickson");
            erickTheSalesDude.Sell();
            Console.WriteLine(erickTheSalesDude.FullName);
        }
    }
}