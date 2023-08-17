using Drewsoft.Chess.Engine.Exceptions;
using Drewsoft.Chess.Engine.Tests;

using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class BoardTests
{
    [Theory]
    [ClassData(typeof(DefaultChessGameTestData))]
    public void Board_Ctor_Parameterless_InitialisesDefaultGame(Reference reference, char? expected)
    {
        var sut = new Board();

        var result = sut[Reference.Parse(reference)];

        result?.Display.Should().Be(expected ?? '-');
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

        var action = () => sut.MakeMove(invalid);

        action.Should().Throw<InvalidMoveException>().WithMessage($"'{invalid}' is not a valid move.*");
    }

    [Fact]
    public void Board_Move_LegalMove_InitialPosition_ReturnsNewBoard()
    {
        var sut = new Board();

        var result = sut.MakeMove("a2a4");

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

        var result = sut.MakeMove(move);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialLegalMoves), MemberType = typeof(BoardTestData))]
    public void Board_Move_LegalMove_InitialPosition_ReturnsNewBoardPosition(string move, string expectedBoard)
    {
        var sut = new Board();

        var result = sut.MakeMove(move);

        result.Should().BeEquivalentTo(expectedBoard, opts => opts.WithStrictOrdering());
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialEmptyPositions), MemberType = typeof(BoardTestData))]
    public void Board_Move_NoPiece_ThrowsPieceNotFoundException(string emptyPosition)
    {
        var sut = new Board();
        var move = $"{emptyPosition}h8";

        var action = () => sut.MakeMove(move);

        action.Should().Throw<PieceNotFoundException>().WithPosition(emptyPosition);
    }

    [Theory]
    [MemberData(nameof(BoardTestData.StandardChessInitialOpposingPositions), MemberType = typeof(BoardTestData))]
    public void Board_Move_OpposingPiece_ThrowsOpposingPieceException(string opposingPosition)
    {
        var sut = new Board();
        var move = $"{opposingPosition}e5";

        var action = () => sut.MakeMove(move);

        action.Should().Throw<OpposingPieceException>().WithPosition(opposingPosition);
    }

    [Theory]
    [InlineData("a2a5")]  // Pawn forward 3
    [InlineData("a2b3")]  // Pawn diagonal
    [InlineData("a1a2")]  // Rook to pawn
    [InlineData("a1a5")]  // Rook through pawn
    [InlineData("a1b1")]  // Rook to knight
    [InlineData("b1b3")]  // Knight forward 2
    [InlineData("b1d2")]  // Knight to pawn
    [InlineData("b1d3")]  // Knight diagonal 2
    [InlineData("c1b2")]  // Bishop to pawn
    [InlineData("c1f4")]  // Bishop through pawn
    [InlineData("d1c2")]  // Queen to pawn
    [InlineData("d1d2")]  // Queen to pawn
    [InlineData("d1e2")]  // Queen to pawn
    [InlineData("d1d5")]  // Queen through pawn
    [InlineData("e1d2")]  // King to pawn
    [InlineData("e1e2")]  // King to pawn
    [InlineData("e1f2")]  // King to pawn
    [InlineData("e1c1")]  // Queen-side castle
    [InlineData("e1g1")]  // King-side castle
    public void Board_Move_InitialPosition_IllegalMove_ThrowsIllegalMoveException(string illegalMove)
    {
        var sut = new Board();

        var action = () => sut.MakeMove(illegalMove);

        action.Should().Throw<IllegalMoveException>().WithMove(illegalMove);
    }
}
