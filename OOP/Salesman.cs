namespace OOP
{
    public abstract class Salesman
    {
                //fields: they should be private
        private string _firstName;
        private string _lastName;

        //property: this is what we use to expose the value of the fields
        //Propeties are captallized: PropertyName
        //Fields have underscores: _fieldName
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this._firstName, this._lastName);
            }
        }

        //The constructor must have the same name of the class
        public Salesman(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }

        public abstract void Sell();
    }
}