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
        if (file < 'a' || file > 'h') { throw new ArgumentOutOfRangeException(nameof(file)); }
        if (rank < 1 || rank > 8) { throw new ArgumentOutOfRangeException(nameof(rank)); }

        _value = 8 * (8 - rank) + file - 'a';
    }

    public static Reference Parse(string candidate)
        => candidate.Length == 2
            ? new(candidate[0], candidate[1] - '0')
            : throw new ArgumentException("The value must be 2 characters in length.", nameof(candidate));

    public override string ToString() => $"{"abcdefgh"[_value % 8]}{8 - _value / 8}";

    public static implicit operator string(Reference reference) => reference.ToString();
}
