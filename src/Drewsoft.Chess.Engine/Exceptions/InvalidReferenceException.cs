namespace Drewsoft.Chess.Engine.Exceptions;

public class InvalidReferenceException : ChessException
{
    public InvalidReferenceException(string message, string reference)
        : base(CreateMessage(message, reference))
    {
        Reference = reference;
    }

    public InvalidReferenceException(string message, string reference, Exception innerException)
        : base(CreateMessage(message, reference), innerException)
    {
        Reference = reference;
    }

    private static string CreateMessage(string message, string reference)
        => $"'{reference}' is not a valid reference. {message}";

    public string Reference { get; }
}
