namespace Restaurant365.Challenge.Calculator.Application.Infrastructure;

public class ConsoleOutputStream : IOutputStream
{
    public void Write(string output)
    {
        Console.WriteLine(output);
    }
}