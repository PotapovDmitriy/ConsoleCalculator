namespace ConsoleCalculator.Helpers;

public static class ExpressionValidatorHelper
{
    public static void IsValidExpression(string expression, HashSet<char> operations)
    {
        if (string.IsNullOrEmpty(expression))
        {
            throw new ArgumentNullException(nameof(expression));
        }

        var openBracketCount = 0;
        foreach (var c in expression)
        {
            switch (c)
            {
                case '(':
                    openBracketCount++;
                    break;
                case ')':
                {
                    openBracketCount--;
                    if (openBracketCount < 0)
                    {
                        throw new ArgumentException("Закрывающихся скобок больше, чем открывающихся!");
                    }

                    break;
                }
            }
        }

        if (openBracketCount != 0)
        {
            throw new ArgumentException("Открывающихся скобок больше, чем закрывающихся!");
        }
        
        foreach (var c in expression)
        {
            if (!char.IsDigit(c) && c != '.' && !operations.Contains(c) && c != '(' && c != ')')
            {
                throw new ArgumentException("Выражение содержит недопустимые символы!");
            }
        }
    }
}