namespace ConsoleCalculator.Interfaces;

public interface IOperation
{
    int Priority { get; }
    double Calculate(double operand1, double operand2);
}