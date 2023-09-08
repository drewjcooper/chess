using Drewsoft.Chess.Engine.Exceptions;
using Drewsoft.Chess.Engine.MoveTypes;

using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class ReferenceTests
{
    [Fact]
    public void Reference_Default_Isa1()
    {
        var expected = Reference.Parse("a1");

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
        var action = () => _ = new Reference(value);

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
    [InlineData('@', 1)]
    [InlineData('i', 8)]
    [InlineData('a', 0)]
    [InlineData('h', 9)]
    [InlineData('z', 20)]
    public void Ctor_FileOrRankInvalid_ThrowsInvalidReferenceException(char file, int rank)
    {
        Action action = () => _ = new Reference(file, rank);

        action.Should().Throw<InvalidReferenceException>();
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

        action.Should().Throw<InvalidReferenceException>().WithReference(candidate)
            .WithMessage("* is not a valid reference. The value must be 2 characters in length.");
    }

    [Theory]
    [InlineData("`1")]
    [InlineData("i8")]
    [InlineData("a0")]
    [InlineData("h9")]
    [InlineData("z9")]
    public void Parse_CandidateInvalidValue_ThrowsInvalidReferenceException(string candidate)
    {
        Action action = () => Reference.Parse(candidate);

        action.Should().Throw<InvalidReferenceException>().WithReference(candidate);
    }

    [Theory]
    [InlineData("a8")]
    [InlineData("a7")]
    [InlineData("A6")]
    [InlineData("a5")]
    [InlineData("a4")]
    [InlineData("a3")]
    [InlineData("a2")]
    [InlineData("a1")]
    [InlineData("B1")]
    [InlineData("c1")]
    [InlineData("d1")]
    [InlineData("E1")]
    [InlineData("f1")]
    [InlineData("G1")]
    [InlineData("h1")]
    public void ToString_AfterParse_ReturnsInitialStringLowered(string candidate)
    {
        var sut = Reference.Parse(candidate);

        var result = sut.ToString();

        result.Should().Be(candidate.ToLower());
    }

    [Theory]
    [InlineData("d4", 0, 1, "d5")]
    [InlineData("d4", 1, 1, "e5")]
    [InlineData("d4", 1, 0, "e4")]
    [InlineData("d4", 1, -1, "e3")]
    [InlineData("d4", 0, -1, "d3")]
    [InlineData("d4", -1, -1, "c3")]
    [InlineData("d4", -1, 0, "c4")]
    [InlineData("d4", -1, 1, "c5")]
    [InlineData("b7", -1, 1, "a8")]
    [InlineData("g7", 1, 1, "h8")]
    [InlineData("g2", 1, -1, "h1")]
    [InlineData("b2", -1, -1, "a1")]
    public void TryStep_ValidStep_ReturnsTrueAndNewReference(string from, int fileDelta, int rankDelta, string expected)
    {
        var fromReference = Reference.Parse(from);
        var step = new Step(fileDelta, rankDelta);

        var result = fromReference.TryStep(step, out var toReference);

        result.Should().BeTrue();
        toReference.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData("a8", 0, 1)]
    [InlineData("d8", 1, 1)]
    [InlineData("h8", 1, 0)]
    [InlineData("h4", 1, -1)]
    [InlineData("h1", 0, -1)]
    [InlineData("d1", -1, -1)]
    [InlineData("a1", -1, 0)]
    [InlineData("a4", -1, 1)]
    public void TryStep_AtEdgeOfBoard_ReturnsFalseAndSameReference(string from, int fileDelta, int rankDelta)
    {
        var fromReference = Reference.Parse(from);
        var step = new Step(fileDelta, rankDelta);

        var result = fromReference.TryStep(step, out var toReference);

        result.Should().BeFalse();
        toReference.ToString().Should().Be(from);
    }
}
