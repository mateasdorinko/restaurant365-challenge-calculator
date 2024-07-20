namespace Restaurant365.Challenge.Calculator.Application.Exceptions;

public class DelimitedValueCountExceededException() 
    : ApplicationException("More than 2 delimited items are not allowed.");