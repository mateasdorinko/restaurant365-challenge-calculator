namespace Tests.Unit.Infrastructure.Implementations.CalculatorTests;

public class Add
{
    private readonly Calculator _calculator = new Calculator(new DelimitedInputParser());

    [Fact]
    public void providing_a_single_numeric_delimited_value_returns_the_same_value()
    {
        // arrange
        const string input = "20";
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void providing_multiple_positive_values_returns_sum()
    {
        // arrange
        const string input = "1,5000";
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(5001, result);
    }

    [Fact(Skip = "Removed negative numbers as valid delimited values.")]
    public void providing_multiple_values_with_negative_returns_sum()
    {
        // arrange
        const string input = "4,-3";
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void providing_multiple_values_past_ceiling_limit_returns_sum()
    {
        // arrange
        const string input = "1,2,3,4,5,6,7,8,9,10,11,12";
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(78, result);
    }

    [Fact]
    public void providing_negative_delimited_values_throws_delimitednegativevalueexception()
    {
        // arrange
        const string input = "1,2,3,4,-5,-6,7,8,-9";
        
        // act & assert
        var exception = Assert.Throws<DelimitedNegativeValueException>(() => { _calculator.Add(input); });
    }
}