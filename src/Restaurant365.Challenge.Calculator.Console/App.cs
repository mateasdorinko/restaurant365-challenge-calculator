using Restaurant365.Challenge.Calculator.Application.Interfaces;

namespace Restaurant365.Challenge.Calculator.Console;

public class App(ICalculator calculator)
{
    private readonly ICalculator _calculator = calculator;

    public void Run(string[] args)
    {
        System.Console.WriteLine("Enter your comma delimited list of numbers for addition:");
        var commaDelimitedNumbers = System.Console.ReadLine();

        var addResult = _calculator.Add(commaDelimitedNumbers!);
        System.Console.WriteLine(addResult);

        System.Console.Read();
    }
}
