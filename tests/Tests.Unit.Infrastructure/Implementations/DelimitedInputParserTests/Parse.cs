namespace Tests.Unit.Infrastructure.Implementations.DelimitedInputParserTests;

public class Parse
{
    private readonly DelimitedInputParser _delimitedInputParser = new();
    
    [Fact(Skip = "Removed delimited list count over 2 exception requirement")]
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

    [Fact]
    public void newline_character_is_supported_delimiter()
    {
        // arrange
        const string input = "1\n2,3";

        // act
        var result = _delimitedInputParser.Parse(input);

        // assert
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void negative_numbers_within_delimited_list_throws_delimitednegativevalueexception()
    {
        // arrange
        const string input = "1,2,3,4,-5,-6,7,8,-9";

        // act
        var exception = Assert.Throws<DelimitedNegativeValueException>(() => { _delimitedInputParser.Parse(input); });

        // assert
        Assert.Equal("Negative delimited values are not allowed. The following negative values have been identified: [-5, -6, -9]", exception.Message);
    }
}