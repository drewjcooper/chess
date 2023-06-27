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

    [Theory]
    [InlineData("")]
    [InlineData("a2")]
    [InlineData("i2i4")]
    [InlineData("a0a2")]
    [InlineData("a2a")]
    [InlineData("a2a4q")]
    [InlineData("b5b9")]
    [InlineData("2a4a")]
    [InlineData("n&[@")]
    public void Board_Move_InvalidMove_ThrowsInvalidMoveException(string invalid)
    {
        var sut = new Board();

        var action = () => sut.Move(invalid);

        action.Should().Throw<InvalidMoveException>().WithMessage($"'{invalid}' is not a valid move.");
    }

    [Fact]
    public void Board_Move_LegalMove_InitialPosition_ReturnsNewBoard()
    {
        var sut = new Board();

        var result = sut.Move("a2a4");

        result.Should().NotBeSameAs(sut);
    }

    [Theory]
    [InlineData("b2b4")]
    [InlineData("B2b4")]
    [InlineData("b2B4")]
    [InlineData("B2B4")]
    public void Board_Move_IsCaseInsensitive(string move)
    {
        var sut = new Board();
        var expected =
            "rnbqkbnr" +
            "pppppppp" +
            "--------" +
            "--------" +
            "-P------" +
            "--------" +
            "P-PPPPPP" +
            "RNBQKBNR";

        var result = sut.Move(move);

        result.Should().BeEquivalentTo(expected);
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

    [Theory]
    [InlineData("a2a5")]
    [InlineData("a2b3")]
    [InlineData("a1a2")]
    [InlineData("a1a5")]
    [InlineData("a1b1")]
    [InlineData("b1b3")]
    [InlineData("b1d2")]
    [InlineData("b1d3")]
    [InlineData("c1b2")]
    [InlineData("c1f4")]
    [InlineData("d1c2")]
    [InlineData("d1d2")]
    [InlineData("d1e2")]
    [InlineData("d1d5")]
    [InlineData("e1d2")]
    [InlineData("e1e2")]
    [InlineData("e1f2")]
    [InlineData("e1c1")]
    [InlineData("e1g1")]
    public void Board_Move_InitialPosition_IllegalMove_ThrowsIllegalMoveException(string illegalMove)
    {
        var sut = new Board();

        var action = () => sut.Move(illegalMove);

        action.Should().Throw<IllegalMoveException>().WithMove(illegalMove);
    }
}
