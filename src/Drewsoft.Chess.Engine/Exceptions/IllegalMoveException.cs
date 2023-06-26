namespace Drewsoft.Chess.Engine.Exceptions;

public class IllegalMoveException : ChessException
{
    public IllegalMoveException(string move)
        : base($"'{move}' is not a legal move.")
    {
        Move = move;
    }

    public string Move { get; }
}