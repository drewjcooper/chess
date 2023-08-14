using Drewsoft.Chess.Engine.Exceptions;

namespace Drewsoft.Chess.Engine;

public readonly struct Move
{
    public Move(Reference from, Reference to)
    {
        if (from == to)
        {
            throw new InvalidMoveException("The start and end of the move must be different.", $"{from}{to}");
        }

        From = from;
        To = to;
    }

    public Reference From { get; }
    public Reference To { get; }

    public static Move Parse(string candidate)
    {
        if (candidate.Length != 4)
        {
            throw new InvalidMoveException("The value must be 4 characters in length.", candidate);
        }

        try
        {
            return new Move(Reference.Parse(candidate[..2]), Reference.Parse(candidate[2..]));
        }
        catch (Exception ex)
        {
            throw new InvalidMoveException(candidate, ex);
        }
    }

    public override string ToString() => $"{From}{To}";
}