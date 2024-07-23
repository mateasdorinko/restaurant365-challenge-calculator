namespace Tests.Unit.Application.Infrastructure.CalculatorTests;

public class Subtract
{
    private readonly IDelimitedInputParser _parser;
    private readonly ICalculator _calculator;

    public Subtract()
    {
        _parser = A.Fake<IDelimitedInputParser>();
        _calculator = new Calculator(_parser, A.Fake<IOutputStream>());
    }

    [Fact]
    public void throws_not_implemented()
    {
        // arrange
        const string input = "";
        
        // act & assert
        Assert.Throws<NotImplementedException>(() => { _calculator.Subtract(input); });
    }
}