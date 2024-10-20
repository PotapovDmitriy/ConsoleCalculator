using System.Globalization;
using ConsoleCalculator.Helpers;
using ConsoleCalculator.Interfaces;
using ConsoleCalculator.Models.Operations;


namespace ConsoleCalculator.Models;

public class Calculator : ICalculator
{
    private readonly Dictionary<char, IOperation> _operations = new()
    {
        { '+', new AdditionOperation() },
        { '-', new SubtractionOperation() },
        { '*', new MultiplicationOperation() },
        { '/', new DivisionOperation() }
    };

    public double Evaluate(string expression)
    {
        expression = expression.Replace(" ", string.Empty);
        ExpressionValidatorHelper.IsValidExpression(expression, _operations.Keys.ToHashSet());

        var postfixExpression = ToPostfix(expression);
        return EvaluatePostfix(postfixExpression);
    }

    private string ToPostfix(string infixExpression)
    {
        var postfixExpression = "";
        var operatorsStack = new Stack<char>();

        for (int i = 0; i < infixExpression.Length; i++)
        {
            var currentItem = infixExpression[i];

            if (char.IsDigit(currentItem))
            {
                var number = GetStringNumber(infixExpression, ref i);
                postfixExpression += number + " ";
            }
            else if (_operations.TryGetValue(currentItem, out var operation))
            {
                while (operatorsStack.Count > 0 && operatorsStack.Peek() != '(' &&
                       _operations[operatorsStack.Peek()].Priority >= operation.Priority)
                {
                    postfixExpression += operatorsStack.Pop() + " ";
                }

                operatorsStack.Push(currentItem);
            }
            else
                switch (currentItem)
                {
                    case '(':
                        operatorsStack.Push(currentItem);
                        break;
                    case ')':
                    {
                        while (operatorsStack.Peek() != '(')
                        {
                            postfixExpression += operatorsStack.Pop() + " ";
                        }

                        operatorsStack.Pop();
                        break;
                    }
                }
        }
        
        while (operatorsStack.Count > 0)
        {
            postfixExpression += operatorsStack.Pop() + " ";
        }

        return postfixExpression.Trim();
    }

    private double EvaluatePostfix(string postfixExpression)
    {
        var operandsStack = new Stack<double>();

        foreach (var token in postfixExpression.Split(' '))
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var operand))
            {
                operandsStack.Push(operand);
            }
            else if (_operations.ContainsKey(token[0]))
            {
                var operand2 = operandsStack.Pop();
                var operand1 = operandsStack.Pop();

                operandsStack.Push(_operations[token[0]].Calculate(operand1, operand2));
            }
        }

        return operandsStack.Pop();
    }

    private string GetStringNumber(string expression, ref int position)
    {
        var strNumber = "";
        for (; position < expression.Length; position++)
        {
            var c = expression[position];
            if (char.IsDigit(c) || c == '.')
                strNumber += c;
            else
            {
                position--;
                break;
            }
        }

        return strNumber;
    }
}