using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class MultiplicationOperation : IOperation
{
    public int Priority => 2;

    public double Calculate(double operand1, double operand2)
        => operand1 * operand2;
}