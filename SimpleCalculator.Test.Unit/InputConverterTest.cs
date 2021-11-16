using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 

namespace SimpleCalculator.Test.Unit;

[TestClass]
public class InputConverterTest
{
    private readonly CalcEngine _calculatorEngine = new CalcEngine();

    private readonly InputConverter _inputConverter = new InputConverter();
    [TestMethod]
    public void ConvertsValidStringInputIntoDouble()
    {
        string inputNumber = "5";
        double convertedNumber = _inputConverter.ConvertToNumeric(inputNumber);
        Assert.AreEqual(5, convertedNumber);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException ))]
    public void  failsToConvertInvalidStringInputIntoDouble()
    {
        string inputNumber = "$";
        double convertedNumber = _inputConverter.ConvertToNumeric(inputNumber);
    }

}