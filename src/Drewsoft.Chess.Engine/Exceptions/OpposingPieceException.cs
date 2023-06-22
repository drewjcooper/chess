namespace Drewsoft.Chess.Engine.Exceptions;

public class OpposingPieceException : ChessException
{
    public OpposingPieceException(string position)
        : base($"Position {position} contains an opposing piece.")
    {
        Position = position;
    }

    public string Position { get; }
}
