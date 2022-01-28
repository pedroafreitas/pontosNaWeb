using  WebScraper.Notes;

namespace WebScraper.Notes
{
    class PersonBuilder
    {
        private string? _ssn;
        private string? _passportData;
        private string? _driverLicenseNumber;
        private string? _firstName;
        private string? _lastName;
        private int _age;
        private int _eyeColor;

        public PersonBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _ssn = "data";
            _passportData = "data";
            _driverLicenseNumber = "123";
            _firstName = "Anna";
            _lastName = "Clara";
            _age = 21;
            _eyeColor = 255;
        }

        public PersonBuilder SetSsn(string ssn)
        {
            _ssn = ssn;
            return this;
        }

        public PersonBuilder SetPassportData(string passportData)
        {
            _passportData = passportData;
            return this;
        }

        public PersonBuilder SetDriverLicenseNumber(string driverLicenseNumber)
        {
            _driverLicenseNumber = driverLicenseNumber;
            return this;
        }

        public PersonBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public PersonBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public PersonBuilder SetAge(int age)
        {
            _age = age;
            return this;
        }

        public PersonBuilder SetEyeColor(int eyeColor)
        {
            _eyeColor = eyeColor;
            return this;
        }

        public Person Build()
        {
            Person person = new Person(_ssn, _passportData, _driverLicenseNumber, _firstName, _lastName, _age, _eyeColor);
            return person;
        }
    }
}