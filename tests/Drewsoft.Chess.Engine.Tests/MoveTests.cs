using Drewsoft.Chess.Engine.Exceptions;

using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class MoveTests
{
    [Fact]
    public void Move_Default_Isa8a8()
    {
        Move sut = default;

        sut.ToString().Should().Be("a8a8");
    }

    [Fact]
    public void Ctor_FromSameAsTo_ThrowsInvalidMoveException()
    {
        var reference = Reference.Parse("a1");

        var action = () => _ = new Move(reference, reference);

        action.Should().Throw<InvalidMoveException>()
            .WithMessage("* is not a valid move. The start and end of the move must be different.")
            .WithMove($"{reference}{reference}");
    }

    [Theory]
    [InlineData("a1", "a2")]
    [InlineData("a1", "h8")]
    [InlineData("a8", "d3")]
    public void Ctor_FromAndToDistinct_CreatesExpectedMove(string from, string to)
    {
        var fromRef = Reference.Parse(from);
        var toRef = Reference.Parse(to);
        var expected = new { From = fromRef, To = toRef };

        var sut = new Move(fromRef, toRef);

        sut.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("a1a3-")]
    [InlineData("")]
    [InlineData("a1")]
    [InlineData("a1b")]
    [InlineData("a1b2-")]
    public void Parse_CandidateInvalidLength_ThrowsArgumentException(string candidate)
    {
        Action action = () => Move.Parse(candidate);

        action.Should().Throw<InvalidMoveException>().WithMove(candidate)
            .WithMessage("* is not a valid move. The value must be 4 characters in length.");
    }

    [Theory]
    [InlineData("`1b2", "`1")]
    [InlineData("i8b3", "i8")]
    [InlineData("a1a0", "a0")]
    [InlineData("g8h9", "h9")]
    [InlineData("z9a2", "z9")]
    public void Parse_CandidateInvalidValue_ThrowsInvalidReferenceException(string candidate, string expected)
    {
        Action action = () => Move.Parse(candidate);

        action.Should().Throw<InvalidMoveException>().WithMove(candidate)
            .WithInnerException<InvalidReferenceException>().WithReference(expected);
    }

    [Theory]
    [InlineData("a1a8")]
    [InlineData("A3a7")]
    [InlineData("b1G5")]
    [InlineData("C2H1")]
    public void ToString_AfterParse_ReturnsLoweredInitialString(string candidate)
    {
        var sut = Move.Parse(candidate);

        var result = sut.ToString();

        result.Should().Be(candidate.ToLower());
    }
}
