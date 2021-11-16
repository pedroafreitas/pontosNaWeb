using System;

namespace SimpleCalculator
{
    class StringToIntConverter
    {
        public int convert(string input)
        {
            try 
            {
                int convertedNumber;
                bool isConvertedSuccessfully = int.TryParse(input, out convertedNumber);

                if (!isConvertedSuccessfully)
                {
                    throw new Exception("Not converted successfully");
                }

                return convertedNumber;
            } catch(Exception ex) {
               throw;   //this is specific to conversion
               //throw ex; is a bad practice because we remove the stack trace and can't track the origin of the problem.
            }
        }
    }
}