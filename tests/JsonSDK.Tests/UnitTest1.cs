namespace JsonSDK.Tests;

public class MinifyJsonTests
{
    [Fact]
    public void Minify_Should_Remove_Whitespace_Outside_Strings()
    {
        var input = "{\t\t\n\n \t \t\"name\" :\n\n\n\"Bernard\"  ,\t\t\t\t\n\n\n     \"age\" :\t\t\t\t\n\n\n24\n\t\t\n  \n }";
        var expected = "{\"name\":\"Bernard\",\"age\":24}";
        var result = JsonSDK.MinifyJson(input, validate: true);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Minify_Should_Not_Remove_Spaces_Inside_Strings()
    {
        var input = "{ \"message\" : \"hello world\" }";
        var expected = "{\"message\":\"hello world\"}";
        var result = JsonSDK.MinifyJson(input, validate: true);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Minify_Should_Handle_Escaped_Quotes()
    {
        var input = "{ \"text\" : \"He said \\\"hello\\\"\" }";
        var expected = "{\"text\":\"He said \\\"hello\\\"\"}";
        var result = JsonSDK.MinifyJson(input , validate: true);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Minify_Should_Throw_On_Null_Input()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => JsonSDK.MinifyJson(null!, validate: true));
        Console.WriteLine($"Exception message: {ex.Message}");
    }

    [Fact]
    public void ValidatorJson_Should_NotThrow_For_Valid_Json()
    {
        var input = "{\"name\":\"Bernard\",\"age\":24}";
        Exception ex = Record.Exception(() => Validator.Validate(input));
        Assert.Null(ex);
    }
    
    [Fact]
    public void ValidatorJson_Should_Return_False_For_Invalid_Json()
    {
        var input = "{name:\"Bernard\",age:24}";
        var result = Validator.Validate(input);
        Console.WriteLine(result.ErrorMessage);
        Assert.False(result.IsValid);
    }
}