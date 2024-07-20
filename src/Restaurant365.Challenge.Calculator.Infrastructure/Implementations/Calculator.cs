namespace Restaurant365.Challenge.Calculator.Infrastructure.Implementations;

public class Calculator(IDelimitedInputParser delimitedInputParser) : ICalculator
{
    private readonly IDelimitedInputParser _delimitedInputParser = delimitedInputParser;

    public int Add(string commaDelimitedInput)
    {
        var numbers = _delimitedInputParser.Parse(commaDelimitedInput);
        return numbers.Sum();
    }
}