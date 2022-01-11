namespace OOP
{
    public class CarSalesman : Salesman
    {
        private int _age;
        //base is here to use the base class constructor
        public CarSalesman(string firstName, string lastName, int age) : base(firstName, lastName) 
        {
            this._age = age;
        }

        public override void Sell()
        {
            Console.WriteLine(String.Format("Id my is {0}. I would recommend you to buy this car", this.FullName));
        }
    }
}
