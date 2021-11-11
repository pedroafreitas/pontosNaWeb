using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace BasicCoding.Tests;

[TestClass]
public class WhenProgramRuns
{
    [TestInitialize]
    public void Initialize()
    {
        var w = new System.IO.StringWriter();
        Console.SetOut(w);

        Program.Main(new string[0]); //Passing an empty string to simulate running the program with no command line arguments

        _consoleOutput = w.GetStringBuilder().ToString().Trim();
    }

    [TestMethod]
    public void SaysHelloWorld()
    {
        Assert.AreEqual("Hello World", _consoleOutput);
    }
}