using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class ExponentiationOperation : IOperation
{
    public int Priority => 3;

    public double Calculate(double operand1, double operand2)
        => Math.Pow(operand1, operand2);
}