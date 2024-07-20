using Restaurant365.Challenge.Calculator.Application.Interfaces;

namespace Restaurant365.Challenge.Calculator.Console;

public class App(ICalculator calculator)
{
    private readonly ICalculator _calculator = calculator;

    public void Run(string[] args)
    {
        System.Console.WriteLine("hello there...");
        System.Console.Read();
    }
}
