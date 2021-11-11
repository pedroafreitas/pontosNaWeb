using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCoding.Tests;

[TestClass]
public class WhenProgramRuns
{
    [TestInitialize]
    public void Initialize()
    {
        var w = new System.IO.StringWriter();
        Console.SetOut(w);

        Program.Main(new string[0]);

        _consoleOutput = w.GetStringBuilder().ToString().Trim();
    }

    [TestMethod]
    public void SaysHelloWorld()
    {
        Assert.AreEqual("Hello World", _consoleOutput);
    }
}