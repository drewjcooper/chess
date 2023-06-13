using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class BoardTests
{
    [Theory]
    [ClassData(typeof(DefaultChessGameTestData))]
    public void Board_Ctor_Parameterless_InitialisesDefaultGame(string reference, string expected)
    {
        var sut = new Board();

        var result = sut[reference];

        result.Should().Be(expected);
    }

    [Fact]
    public void Board_ToString_ReturnsFenString()
    {
        var sut = new Board();

        var result = sut.ToString();

        result.Should().Be("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }

    [Theory]
    [MemberData(nameof(BoardTestData.TryParseFenPositiveCases), MemberType = typeof(BoardTestData))]
    public void Board_TryParse_CandidateValid_ReturnsTrueAndOutputsExpectedBoard(
        string candidate,
        string expectedSquares)
    {
        var result = Board.TryParse(candidate, out var sut);

        result.Should().BeTrue();
        sut.Should().BeEquivalentTo(expectedSquares);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.TryParseToStringRoundTripCases), MemberType = typeof(BoardTestData))]
    public void Board_ToString_AfterSuccessfulTryParse_ReturnsOriginalString(string candidate)
    {
        Board.TryParse(candidate, out var sut).Should().BeTrue();

        var result = sut!.ToString();

        result.Should().Be(candidate);
    }
}
