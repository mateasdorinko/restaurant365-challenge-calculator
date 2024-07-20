namespace Tests.Unit.Infrastructure.Implementations.DelimitedInputParserTests;

public class Parse
{
    private readonly DelimitedInputParser _delimitedInputParser = new();
    
    [Fact(Skip = "Removed exception requirement")]
    public void providing_more_than_two_delimited_values_throws_delimitedvaluecountexceededexception()
    {
        // arrange
        const string input = "1,2,3";

        // act
        var exception = Assert.Throws<DelimitedValueCountExceededException>(() => { _delimitedInputParser.Parse(input); });

        // assert
        Assert.Equal("More than 2 delimited items are not allowed.", exception.Message);
    }
    
    [Fact]
    public void empty_input_should_result_in_single_item_with_value_of_zero()
    {
        // arrange
        const string input = "";
        
        // act
        var result = _delimitedInputParser.Parse(input);

        // assert
        Assert.Single(result);
        Assert.Equal(0, result[0]);
    }
    
    [Fact]
    public void empty_delimited_values_should_be_converted_to_zero()
    {
        // arrange
        const string input = "1,";
        
        // act
        var result = _delimitedInputParser.Parse(input);

        // assert
        Assert.Equal(2, result.Count);
        Assert.Equal(0, result[1]);
    }
    
    [Fact]
    public void invalid_delimited_values_should_be_converted_to_zero()
    {
        // arrange
        const string input = "1,tytyt";
        
        // act
        var result = _delimitedInputParser.Parse(input);

        // assert
        Assert.Equal(2, result.Count);
        Assert.Equal(0, result[1]);
    }
}