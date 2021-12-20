namespace OOP
{
    public class RetailSalesPerson : Salesman
    {

        //We need to build the abstract class first. 
        public RetailSalesPerson(string firstName, string lastName) : base(firstName, lastName) 
        {

        }

        public override void Sell()
        {
            Console.WriteLine(String.Format("Hi, my name is {0}. I would recommend you to buy this pen!", this.FullName));
            
        }
    }
}