using ConsoleCalculator.Enums;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models.Operations;

public class DivisionOperation : IOperation
{
    public PriorityEnum Priority => PriorityEnum.Mid;

    public double Calculate(double operand1, double operand2)
    {
        if (operand2 == 0)
        {
            throw new DivideByZeroException();
        }

        return operand1 / operand2;
    }
}