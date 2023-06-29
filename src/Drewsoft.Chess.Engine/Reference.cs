namespace Drewsoft.Chess.Engine;

public readonly struct Reference
{
    private readonly int _value;

    public Reference(int value) => _value = value;

    public static Reference Parse(string candidate)
    {
        if (candidate.Length == 2)
        {
            var file = candidate[0];
            var rank = candidate[1];

            if (file >= 'a' && file <= 'h' && rank >= '1' && rank <= '8')
            {
                return new((8 - (rank - '0')) * 8 + file - 'a');
            }
        }

        return default;
    }

    public override string ToString() => $"{"abcdefgh"[_value % 8]}{8 - _value / 8}";

    public static implicit operator string(Reference reference) => reference.ToString();
}
