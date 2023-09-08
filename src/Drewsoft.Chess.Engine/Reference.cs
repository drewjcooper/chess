using Drewsoft.Chess.Engine.Exceptions;
using Drewsoft.Chess.Engine.MoveTypes;

namespace Drewsoft.Chess.Engine;

public readonly struct Reference
{
    private readonly int _fileIndex;
    private readonly int _rankIndex;

    public Reference(int value)
    {
        if (value < 0 || value > 63) { throw new ArgumentOutOfRangeException(nameof(value)); }

        _fileIndex = value % 8;
        _rankIndex = 7 - value / 8;
    }

    private Reference(int fileIndex, int rankIndex)
    {
        _fileIndex = fileIndex;
        _rankIndex = rankIndex;
    }

    public Reference(char file, int rank)
    {
        file = char.ToLower(file);

        if (file < 'a' || file > 'h') { throw new InvalidReferenceException("The file is invalid", $"{file}{rank}"); }
        if (rank < 1 || rank > 8) { throw new InvalidReferenceException("The rank is invalid", $"{file}{rank}"); }

        _fileIndex = file - 'a';
        _rankIndex = rank - 1;
    }

    public static Reference Parse(string candidate)
        => candidate.Length == 2
            ? new(candidate[0], candidate[1] - '0')
            : throw new InvalidReferenceException("The value must be 2 characters in length.", candidate);

    internal bool TryStep(Step step, out Reference result)
    {
        if (TryAdd(_fileIndex, step.FileDelta, out var fileIndex) &&
            TryAdd(_rankIndex, step.RankDelta, out var rankIndex))
        {
            result = new Reference(fileIndex, rankIndex);
            return true;
        }

        result = this;
        return false;

        bool TryAdd(int index, int delta, out int result)
        {
            result = index + delta;
            return result >= 0 && result <= 7;
        }
    }

    public override string ToString() => $"{"abcdefgh"[_fileIndex]}{_rankIndex + 1}";

    public static implicit operator string(Reference reference) => reference.ToString();
}
