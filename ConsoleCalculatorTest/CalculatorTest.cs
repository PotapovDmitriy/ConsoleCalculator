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
        Assert.That(5, Is.EqualTo(_calculator.Evaluate("2+3")));
    }

    [Test]
    public void TestSubtraction()
    {
        Assert.That(1, Is.EqualTo(_calculator.Evaluate("3-2")));
    }
    
    [Test]
    public void TestMultiplication()
    {
        Assert.That(6, Is.EqualTo(_calculator.Evaluate("3*2")));
    }
    
    [Test]
    public void TestDivision()
    {
        Assert.That(2, Is.EqualTo(_calculator.Evaluate("4/2")));
    }
    
    [Test]
    public void TestBracket()
    {
        Assert.That(4, Is.EqualTo(_calculator.Evaluate("2*(3-1)")));
    }
}