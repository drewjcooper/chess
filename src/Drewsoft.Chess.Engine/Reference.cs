using Drewsoft.Chess.Engine.Exceptions;

namespace Drewsoft.Chess.Engine;

public readonly struct Reference
{
    private readonly int _value;

    public Reference(int value)
    {
        if (value < 0 || value > 63) { throw new ArgumentOutOfRangeException(nameof(value)); }

        _value = value;
    }

    public Reference(char file, int rank)
    {
        file = char.ToLower(file);

        if (file < 'a' || file > 'h') { throw new InvalidReferenceException("The file is invalid", $"{file}{rank}"); }
        if (rank < 1 || rank > 8) { throw new InvalidReferenceException("The rank is invalid", $"{file}{rank}"); }

        _value = 8 * (8 - rank) + file - 'a';
    }

    public static Reference Parse(string candidate)
        => candidate.Length == 2
            ? new(candidate[0], candidate[1] - '0')
            : throw new InvalidReferenceException("The value must be 2 characters in length.", candidate);

    public override string ToString() => $"{"abcdefgh"[_value % 8]}{8 - _value / 8}";

    public static implicit operator string(Reference reference) => reference.ToString();
}
