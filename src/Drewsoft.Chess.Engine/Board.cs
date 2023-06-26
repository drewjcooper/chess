using System.Collections;
using System.Text.RegularExpressions;

using Drewsoft.Chess.Engine.Exceptions;

namespace Drewsoft.Chess.Engine;

public class Board : IEnumerable<char>
{
    private readonly Dictionary<string, string> _pieces;

    public Board()
    {
        _pieces = new();

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

    public Board(IEnumerable<KeyValuePair<string, string>> pieces)
    {
        _pieces = new(pieces);
    }

    public string? this[string reference] => _pieces.GetValueOrDefault(reference);
    public char? this[int index] => this[ToReference(index)]?[0];

    private string ToReference(int index) => $"{"abcdefgh"[index % 8]}{8 - index / 8}";

    public IEnumerator<char> GetEnumerator() => Enumerable.Range(0, 64).Select(x => this[x] ?? '-').GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Board Move(string move)
    {
        move = move.ToLower();
        if (!Regex.IsMatch(move, "^([a-h][1-8]){2}$"))
        {
            throw new InvalidMoveException(move);
        }

        var (from, to) = (move[..2], move[2..]);

        var piece = this[from] ?? throw new PieceNotFoundException(from);

        return char.IsUpper(piece[0])
            ? new Board(
                _pieces
                    .Where(kv => kv.Key != from)
                    .Append(new(to, piece)))
            : throw new OpposingPieceException(from);
    }
}
