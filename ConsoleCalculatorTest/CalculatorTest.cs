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
        Assert.That(_calculator.Evaluate("2+3"), Is.EqualTo(5));
    }

    [Test]
    public void TestSubtraction()
    {
        Assert.That(_calculator.Evaluate("3-2"), Is.EqualTo(1));
    }
    
    [Test]
    public void TestMultiplication()
    {
        Assert.That(_calculator.Evaluate("3*2"), Is.EqualTo(6));
    }
    
    [Test]
    public void TestDivision()
    {
        Assert.That(_calculator.Evaluate("4/2"), Is.EqualTo(2));
    }
    
    [Test]
    public void TestBracket()
    {
        Assert.That(_calculator.Evaluate("2*(3-1)"), Is.EqualTo(4));
    }   
    
    [Test]
    public void TestFloatingPointNumbers()
    {
        Assert.That(_calculator.Evaluate("5.1+1"), Is.EqualTo(6.1));
    }
    
    [Test]
    public void TestInvalidOperation()
    {
        Assert.Throws<ArgumentException>(() => _calculator.Evaluate("2*3((-1)"));
    }
    
    [Test]
    public void TestNullOperation()
    {
        Assert.Throws<ArgumentNullException>(() => _calculator.Evaluate(null));
    }
}