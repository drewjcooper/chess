namespace Drewsoft.Chess.Engine.Exceptions;

public class InvalidMoveException : ChessException
{
    public InvalidMoveException(string message, string move)
        : base($"'{move}' is not a valid move. {message}")
    {
        Move = move;
    }

    public InvalidMoveException(string move, Exception inner)
        : base($"'{move}' is not a valid move. See inner exepection.", inner)
    {
        Move = move;
    }

    public string Move { get; }
}
