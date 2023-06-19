using Drewsoft.Chess.Engine.Tests;

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
    public void Board_MovePiece_LegalMove_InitialPosition_ReturnsNewBoard()
    {
        var sut = new Board();

        var result = sut.Move("a2a4");

        result.Should().NotBeSameAs(sut);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialLegalMoves), MemberType = typeof(BoardTestData))]
    public void Board_MovePiece_LegalMove_InitialPosition_ReturnsNewBoardPosition(string move, string expectedBoard)
    {
        var sut = new Board();

        var result = sut.Move(move);

        result.Should().BeEquivalentTo(expectedBoard, opts => opts.WithStrictOrdering());
    }
}
