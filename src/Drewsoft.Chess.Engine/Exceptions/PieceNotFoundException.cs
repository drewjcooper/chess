namespace Drewsoft.Chess.Engine.Exceptions;

public class PieceNotFoundException : ChessException
{
    public PieceNotFoundException(string position)
        : base($"There is no piece at {position}.")
    {
        Position = position;
    }

    public string Position { get; }
}
