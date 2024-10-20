using ConsoleCalculator.Models;

Console.WriteLine("Это консольный калькулятор! Для завершения работы введите \"end\"");
while (true)
{
    try
    {
        Console.WriteLine("Введите выражение: ");
        var expression = Console.ReadLine();
        if (expression == "end")
            return;

        var calculator = new Calculator();
        var result = calculator.Evaluate(expression);

        Console.WriteLine($"Результат: {result}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}