namespace Restaurant365.Challenge.Calculator.Application.Infrastructure;

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

    public int Subtract(string delimitedInput) { throw new NotImplementedException(); }

    public int Multiply(string delimitedInput) { throw new NotImplementedException(); }

    public int Divide(string delimitedInput) {  throw new NotImplementedException(); }
}