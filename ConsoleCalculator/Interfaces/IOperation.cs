using ConsoleCalculator.Enums;

namespace ConsoleCalculator.Interfaces;

public interface IOperation
{
    PriorityEnum Priority { get; }
    double Calculate(double operand1, double operand2);
}