namespace WebScraper.Notes
{
    class Person
    {
        //Fields
        private string _ssn;
        private string _passportData;
        private string _driverLicenseNumber;
        string _firstName = "Anna";
        string _lastName = "Veira";

        public int Age {get; set; }
        public int EyeColor {get; set; }

        public Person(string ssn, string passportData, string driverLicenseNumber, string FirstName, string LastName, int Age, int EyeColor)
        {
            //this way we dont need to assign the value directly to the field
            _ssn = ssn;
            _passportData = passportData;
            _driverLicenseNumber = driverLicenseNumber;
            _firstName = FirstName;
            _lastName = LastName;
            this.Age = Age;
            this.EyeColor = EyeColor;
        }
        public bool HasProperDocuments {
            get
            {
                return _ssn.Length > 0 && _passportData.Length > 0 && _driverLicenseNumber.Length > 0;
            }
        }
        //Properties: they abstract away the fields
        public string FirstName{
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length < 1)
                {
                    Console.WriteLine("Input is not accepted");
                    return;
                }
                _firstName = value; //value is a reserved keyword. Value is what you give to the property
            }
        }
        public string LastName{
            get
            {
                return _lastName;
            }
            set
            {
                if(value.Length < 1)
                {
                    Console.WriteLine("Input not accepted");
                    return;
                }
                _lastName = value;
            }
        }
    }
}