using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class AdditionOperation : IOperation
{
    public int Priority => 1;

    public double Calculate(double operand1, double operand2)
        => operand1 + operand2;
}