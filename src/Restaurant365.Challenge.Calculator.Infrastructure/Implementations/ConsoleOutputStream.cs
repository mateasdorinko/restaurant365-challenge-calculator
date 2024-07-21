namespace Restaurant365.Challenge.Calculator.Infrastructure.Implementations;

public class ConsoleOutputStream : IOutputStream
{
    public void Write(string output)
    {
        Console.WriteLine(output);
    }
}