using Illumonos.Extensions.Strings;

namespace Illumonos.Extensions.Tests.Strings;

public class ReverseTests
{
    [Fact]
    public void For_StringExtensions_When_Reverse_With_Null_Then_ThrowsArgumentNullException()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => input!.Reverse());
    }

    [Theory]
    [ClassData(typeof(ReverseValidInputTheoryData))]
    public void For_StringExtensions_When_Reverse_With_ValidInput_Then_ReturnsExpected(string input, string expected)
    {
        string result = input.Reverse();

        Assert.Equal(expected, result);
    }

    private class ReverseValidInputTheoryData : TheoryData<string, string>
    {
        public ReverseValidInputTheoryData()
        {
            Add("", "");
            Add("A", "A");
            Add("AB", "BA");
            Add("Hello, world!", "!dlrow ,olleH");
            Add("   ", "   ");
            Add("e\u0301", "e\u0301");
            Add("A😀B", "B😀A");
            Add("👨‍👩‍👧‍👦X", "X👨‍👩‍👧‍👦");
            Add("A👩‍❤️‍💋‍👨B", "B👩‍❤️‍💋‍👨A");
        }
    }
}