namespace Restaurant365.Challenge.Calculator.Application.Interfaces;

public interface ICalculator
{
    int Add(string delimitedInput);
    int Subtract(string delimitedInput);
    int Multiply(string delimitedInput);
    int Divide(string delimitedInput);
}