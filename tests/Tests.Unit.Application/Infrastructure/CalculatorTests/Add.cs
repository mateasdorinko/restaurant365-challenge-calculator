namespace Tests.Unit.Application.Infrastructure.CalculatorTests;

public class Add
{
    private readonly IDelimitedInputParser _parser;
    private readonly ICalculator _calculator;

    public Add()
    {
        _parser = A.Fake<IDelimitedInputParser>();
        _calculator = new Calculator(_parser, A.Fake<IOutputStream>());
    }
    
    [Fact]
    public void providing_a_single_numeric_delimited_value_returns_the_same_value()
    {
        // arrange
        const string input = "20";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 20 });
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(20, result);
    }

    /*[Fact(Skip = "Values over 1000 are no longer valid. (Requirement 5)")]
    public void providing_multiple_positive_values_returns_sum()
    {
        // arrange
        const string input = "1,5000";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 1,5000 });
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(5001, result);
    }*/

    /*[Fact(Skip = "Removed negative numbers as valid delimited values. (Requirement 4)")]
    public void providing_multiple_values_with_negative_returns_sum()
    {
        // arrange
        const string input = "4,-3";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 4,-3 });
        
        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(1, result);
    }*/

    [Fact]
    public void providing_multiple_values_past_ceiling_limit_returns_sum()
    {
        // arrange
        const string input = "1,2,3,4,5,6,7,8,9,10,11,12";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 1,2,3,4,5,6,7,8,9,10,11,12 });
        
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
        A.CallTo(() => _parser.Parse(input)).Throws(() => new DelimitedNegativeValueException([-5, -6, -9]));
        
        // act & assert
        Assert.Throws<DelimitedNegativeValueException>(() => { _calculator.Add(input); });
    }

    [Fact]
    public void numbers_greater_than_1000_will_be_treated_as_invalid_and_assumed_zero()
    {
        // arrange
        const string input = "2,1001,6";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 2,0,6 });

        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void delimited_list_by_newline_character_is_supported()
    {
        // arrange
        const string input = "1\n2,3";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 1,2,3 });

        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void delimited_list_with_pound_character_is_supported()
    {
        // arrange
        const string input = "//#\n2#5";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 2,5 });

        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void delimited_list_with_pound_and_invalid_characters_supported()
    {
        // arrange
        const string input = "//,\n2,ff,100";
        A.CallTo(() => _parser.Parse(input)).Returns(new List<int>{ 2,100 });

        // act
        var result = _calculator.Add(input);

        // assert
        Assert.Equal(102, result);
    }
}