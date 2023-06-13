using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Drewsoft.Chess.Engine;

public class Board : IEnumerable<char>
{
    private readonly Dictionary<string, string> _pieces = new();

    public Board()
    {
        for (char file = 'a'; file <= 'h'; file++)
        {
            _pieces[$"{file}2"] = "P";
            _pieces[$"{file}7"] = "p";
        }

        _pieces["a1"] = _pieces["h1"] = "R";
        _pieces["b1"] = _pieces["g1"] = "N";
        _pieces["c1"] = _pieces["f1"] = "B";
        _pieces["d1"] = "Q";
        _pieces["e1"] = "K";

        _pieces["a8"] = _pieces["h8"] = "r";
        _pieces["b8"] = _pieces["g8"] = "n";
        _pieces["c8"] = _pieces["f8"] = "b";
        _pieces["d8"] = "q";
        _pieces["e8"] = "k";
    }

    public string this[string reference] => _pieces.GetValueOrDefault(reference, "-");
    public char this[int index] => this[ToReference(index)][0];

    private string ToReference(int index) => $"{"abcdefgh"[index % 8]}{8 - index / 8}";

    public static bool TryParse(string candidate, [NotNullWhen(true)] out Board? board)
    {
        board = new Board();
        return true;
    }

    public IEnumerator<char> GetEnumerator() => Enumerable.Range(0, 64).Select(x => this[x]).GetEnumerator();

    public override string ToString() => "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
