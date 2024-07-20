namespace Restaurant365.Challenge.Calculator.Application.Interfaces;

public interface IDelimitedInputParser
{
    IList<int> Parse(string input);
}