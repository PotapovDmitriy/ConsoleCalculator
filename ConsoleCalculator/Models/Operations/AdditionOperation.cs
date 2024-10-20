using ConsoleCalculator.Enums;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class AdditionOperation : IOperation
{
    public PriorityEnum Priority => PriorityEnum.Low;

    public double Calculate(double operand1, double operand2)
        => operand1 + operand2;
}