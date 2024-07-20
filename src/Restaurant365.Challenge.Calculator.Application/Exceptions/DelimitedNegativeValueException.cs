namespace Restaurant365.Challenge.Calculator.Application.Exceptions;

public class DelimitedNegativeValueException(List<int> negativeNumbers) 
    : ApplicationException($"Negative delimited values are not allowed. The following negative values have been identified: [{string.Join(", ", negativeNumbers)}]");