using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class ReferenceTests
{
    [Fact]
    public void Reference_Default_Isa8()
    {
        var expected = Reference.Parse("a8");

        Reference sut = default;

        sut.Should().Be(expected);
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(64)]
    [InlineData(int.MaxValue)]
    public void Ctor_ValueInvalid_ThrowsArgumentOutOfRangeException(int value)
    {
        Action action = () => new Reference(value);

        action.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("value");
    }

    [Theory]
    [InlineData('a', 1, "a1")]
    [InlineData('a', 8, "a8")]
    [InlineData('h', 1, "h1")]
    [InlineData('h', 8, "h8")]
    [InlineData('d', 4, "d4")]
    public void Ctor_FileAndRankValid_CreatesExpectedReference(char file, int rank, string expected)
    {
        var sut = new Reference(file, rank);

        sut.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData('@', 1, "file")]
    [InlineData('i', 8, "file")]
    [InlineData('a', 0, "rank")]
    [InlineData('h', 9, "rank")]
    [InlineData('z', 20, "file")]
    public void Ctor_FileOrRankInvalid_ThrowsArgumentOutOfRangeException(char file, int rank, string parameterName)
    {
        Action action = () => new Reference(file, rank);

        action.Should().Throw<ArgumentOutOfRangeException>().WithParameterName(parameterName);
    }

    [Theory]
    [InlineData("a8", 0)]
    [InlineData("a7", 8)]
    [InlineData("a6", 16)]
    [InlineData("a5", 24)]
    [InlineData("a4", 32)]
    [InlineData("a3", 40)]
    [InlineData("a2", 48)]
    [InlineData("a1", 56)]
    [InlineData("b1", 57)]
    [InlineData("c1", 58)]
    [InlineData("d1", 59)]
    [InlineData("e1", 60)]
    [InlineData("f1", 61)]
    [InlineData("g1", 62)]
    [InlineData("h1", 63)]
    public void Parse_CandidateValid_ReturnsExpectedReference(string candidate, int expectedValue)
    {
        var expected = new Reference(expectedValue);

        var result = Reference.Parse(candidate);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("a1-")]
    [InlineData("a")]
    [InlineData("1")]
    public void Parse_CandidateInvalidLength_ThrowsArgumentException(string candidate)
    {
        Action action = () => Reference.Parse(candidate);

        action.Should().Throw<ArgumentException>().WithParameterName("candidate")
            .WithMessage("The value must be 2 characters in length.*");
    }

    [Theory]
    [InlineData("`1", "file")]
    [InlineData("i8", "file")]
    [InlineData("a0", "rank")]
    [InlineData("h9", "rank")]
    [InlineData("z9", "file")]
    public void Parse_CandidateInvalidValue_ThrowsArgumentException(string candidate, string parameterName)
    {
        Action action = () => Reference.Parse(candidate);

        action.Should().Throw<ArgumentException>().WithParameterName(parameterName);
    }

    [Theory]
    [InlineData("a8")]
    [InlineData("a7")]
    [InlineData("a6")]
    [InlineData("a5")]
    [InlineData("a4")]
    [InlineData("a3")]
    [InlineData("a2")]
    [InlineData("a1")]
    [InlineData("b1")]
    [InlineData("c1")]
    [InlineData("d1")]
    [InlineData("e1")]
    [InlineData("f1")]
    [InlineData("g1")]
    [InlineData("h1")]
    public void ToString_AfterParse_ReturnsInitialString(string candidate)
    {
        var sut = Reference.Parse(candidate);

        var result = sut.ToString();

        result.Should().Be(candidate);
    }
}
