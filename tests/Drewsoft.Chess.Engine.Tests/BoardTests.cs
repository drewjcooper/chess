using Drewsoft.Chess.Engine.Exceptions;
using Drewsoft.Chess.Engine.Tests;

using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class BoardTests
{
    [Theory]
    [ClassData(typeof(DefaultChessGameTestData))]
    public void Board_Ctor_Parameterless_InitialisesDefaultGame(string reference, string? expected)
    {
        var sut = new Board();

        var result = sut[reference];

        result.Should().Be(expected);
    }

    [Fact]
    public void Board_Move_LegalMove_InitialPosition_ReturnsNewBoard()
    {
        var sut = new Board();

        var result = sut.Move("a2a4");

        result.Should().NotBeSameAs(sut);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialLegalMoves), MemberType = typeof(BoardTestData))]
    public void Board_Move_LegalMove_InitialPosition_ReturnsNewBoardPosition(string move, string expectedBoard)
    {
        var sut = new Board();

        var result = sut.Move(move);

        result.Should().BeEquivalentTo(expectedBoard, opts => opts.WithStrictOrdering());
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialEmptyPositions), MemberType = typeof(BoardTestData))]
    public void Board_Move_NoPiece_ThrowsPieceNotFoundException(string emptyPosition)
    {
        var sut = new Board();
        var move = $"{emptyPosition}h8";

        var action = () => sut.Move(move);

        action.Should().Throw<PieceNotFoundException>().WithPosition(emptyPosition);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialOpposingPositions), MemberType = typeof(BoardTestData))]
    public void Board_Move_OpposingPiece_ThrowsOpposingPieceException(string opposingPosition)
    {
        var sut = new Board();
        var move = $"{opposingPosition}e5";

        var action = () => sut.Move(move);

        action.Should().Throw<OpposingPieceException>().WithPosition(opposingPosition);
    }


}
