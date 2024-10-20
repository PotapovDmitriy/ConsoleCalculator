using ConsoleCalculator.Enums;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class MultiplicationOperation : IOperation
{
    public PriorityEnum Priority => PriorityEnum.Mid;

    public double Calculate(double operand1, double operand2)
        => operand1 * operand2;
}