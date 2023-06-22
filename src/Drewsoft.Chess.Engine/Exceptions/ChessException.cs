namespace Drewsoft.Chess.Engine.Exceptions;

public abstract class ChessException : Exception
{
    protected ChessException(string message)
        : base(message)
    {
    }

    public ChessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}