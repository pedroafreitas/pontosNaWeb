namespace SimpleCalculator
{
    public class CalcEngine 
    {
        public double Calc(string argOperation, double argFirstNumber, double argSecondNumber){
            
            double result;

            argOperation = argOperation.ToLower();

            switch (argOperation)
            {
                case "add":
                case "+":
                    result = argFirstNumber + argSecondNumber;
                    break;
                                
                case "minus":
                case "-":
                    result = argFirstNumber - argSecondNumber;
                    break;
                                    
                case "times":
                case "*":
                    result = argFirstNumber * argSecondNumber;
                    break;
                
                case "by":
                case "/":
                    result = argFirstNumber / argSecondNumber;
                    break;
                
                default:
                    throw new InvalidOperationException("Specified operation is not recognized."); 
            }

            return result;
        }
    }
}