using ConsoleCalculator.Interfaces;
using ConsoleCalculator.Models;
using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private ICalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void TestAddition()
    {
        Assert.Equals(5, _calculator.Evaluate("2+3"));
    }

    [Test]
    public void TestSubtraction()
    {
        Assert.Equals(1, _calculator.Evaluate("3-2"));
    }
    
    [Test]
    public void TestMultiplication()
    {
        Assert.Equals(6, _calculator.Evaluate("3*2"));
    }
    
    [Test]
    public void TestDivision()
    {
        Assert.Equals(2, _calculator.Evaluate("4/2"));
    }
}