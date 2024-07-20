namespace Restaurant365.Challenge.Calculator.Infrastructure.Implementations;

public class DelimitedInputParser : IDelimitedInputParser
{
    public IList<int> Parse(string input)
    {
        var numbers = new List<int>();
        var delimited = input.Split([',', '\n']);

        // if (delimited is { Length: > 2 }) { throw new DelimitedValueCountExceededException(); }

        if (delimited.Length == 0)
        {
            numbers.Add(0);
            return numbers;
        }

        foreach (var value in delimited)
        {
            var success = int.TryParse(value, out var number);
            numbers.Add(success && number <= 1000 ? number : 0);
        }

        var negativeNumbers = numbers.Where(x => x < 0).ToList();
        if (negativeNumbers.Count != 0) { throw new DelimitedNegativeValueException(negativeNumbers); }

        return numbers;
    }
}