using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit;

[TestClass]
public class CalcEngineTest
{
    private readonly CalcEngine _calculatorEngine = new CalcEngine();

    [TestMethod]
    public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
    {
        int number1 = 1;
        int number2  = 2; 
        double result = _calculatorEngine.Calc("add", number1, number2);

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void AddsTwoNumbersAndReturnsValidResultForSymbolOperation()
    {
        int number1 = 1;
        int number2  = 2; 
        double result = _calculatorEngine.Calc("+", number1, number2);

        Assert.AreEqual(3, result);
    }
}