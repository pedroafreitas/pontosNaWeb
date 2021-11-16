namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertToNumeric(string argInput)
        {
            double convertedNumber;

            if(!double.TryParse(argInput, out convertedNumber)) throw new ArgumentException("Expected numerical input.");

            return convertedNumber;
        }
    }
}