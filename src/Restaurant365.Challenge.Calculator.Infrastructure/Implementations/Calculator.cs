namespace Restaurant365.Challenge.Calculator.Infrastructure.Implementations;

public class Calculator(IDelimitedInputParser delimitedInputParser, IOutputStream outputStream) : ICalculator
{
    public int Add(string delimitedInput)
    {
        outputStream.Write($"Provided input: {delimitedInput} ");
        
        var numbers = delimitedInputParser.Parse(delimitedInput);
        var sum = numbers.Sum();
        outputStream.Write($"Parsed formula and answer: {string.Join("+", numbers)} = {sum}");

        return sum;
    }
}