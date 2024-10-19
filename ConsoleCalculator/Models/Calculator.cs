using System.Globalization;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.Models;

public class Calculator : ICalculator
{
    private readonly Dictionary<char, int> _operationPriority = new()
    {
        { '(', 0 },
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 },
    };

    private string GetStringNumber(string expression, ref int position)
    {
        var strNumber = "";

        for (; position < expression.Length; position++)
        {
            var num = expression[position];
            if (char.IsDigit(num))
                strNumber += num;
            else
            {
                position--;
                break;
            }
        }
        return strNumber;
    }

    private string ToPostfix(string infixExpr)
    {
        var postfixExpression = "";
        Stack<char> resultStack = new();
        for (var i = 0; i < infixExpr.Length; i++)
        {
            var currentItem = infixExpr[i];
            if (char.IsDigit(currentItem))
                postfixExpression += GetStringNumber(infixExpr, ref i) + " ";
            else switch (currentItem)
            {
                case '(':
                    resultStack.Push(currentItem);
                    break;
                case ')':
                {
                    while (resultStack.Count > 0 && resultStack.Peek() != '(')
                        postfixExpression += resultStack.Pop();
                    resultStack.Pop();
                    break;
                }
                default:
                {
                    if (_operationPriority.TryGetValue(currentItem, out var operationPriority))
                    {
                        while (resultStack.Count > 0 && (_operationPriority[resultStack.Peek()] >= operationPriority))
                            postfixExpression += resultStack.Pop();
                        resultStack.Push(currentItem);
                    }

                    break;
                }
            }
        }

        return resultStack.Aggregate(postfixExpression, (current, op) => current + op);
    }

    private double Execute(char op, double first, double second)
    {
        return op switch
        {
            '+' => first + second,
            '-' => first - second,
            '*' => first * second,
            '/' => first / second,
            _ => 0
        };
    }

    public double Evaluate(string expression)
    {
        expression = expression.Replace(" ", string.Empty);
        var postfixExpr = ToPostfix(expression);
        Stack<double> locals = new();
        for (var i = 0; i < postfixExpr.Length; i++)
        {
            var currentItem = postfixExpr[i];
            if (char.IsDigit(currentItem))
                locals.Push(Convert.ToDouble(GetStringNumber(postfixExpr, ref i), CultureInfo.InvariantCulture));
            else if (_operationPriority.ContainsKey(currentItem))
            {
                double second = locals.Count > 0 ? locals.Pop() : 0,
                    first = locals.Count > 0 ? locals.Pop() : 0;
                locals.Push(Execute(currentItem, first, second));
            }
        }
        return locals.Pop();
    }
}
