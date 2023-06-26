namespace Drewsoft.Chess.Engine.Exceptions;

public class InvalidMoveException : ChessException
{
    public InvalidMoveException(string move)
        : base($"'{move}' is not a valid move.")
    {
    }
}
