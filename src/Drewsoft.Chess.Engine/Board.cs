using System.Collections;
using System.Text.RegularExpressions;

using Drewsoft.Chess.Engine.Exceptions;

namespace Drewsoft.Chess.Engine;

public class Board : IEnumerable<char>
{
    private readonly Dictionary<Reference, char> _pieces;

    public Board()
    {
        _pieces = new();

        for (char file = 'a'; file <= 'h'; file++)
        {
            _pieces[Reference.Parse($"{file}2")] = 'P';
            _pieces[Reference.Parse($"{file}7")] = 'p';
        }

        _pieces[Reference.Parse("a1")] = _pieces[Reference.Parse("h1")] = 'R';
        _pieces[Reference.Parse("b1")] = _pieces[Reference.Parse("g1")] = 'N';
        _pieces[Reference.Parse("c1")] = _pieces[Reference.Parse("f1")] = 'B';
        _pieces[Reference.Parse("d1")] = 'Q';
        _pieces[Reference.Parse("e1")] = 'K';

        _pieces[Reference.Parse("a8")] = _pieces[Reference.Parse("h8")] = 'r';
        _pieces[Reference.Parse("b8")] = _pieces[Reference.Parse("g8")] = 'n';
        _pieces[Reference.Parse("c8")] = _pieces[Reference.Parse("f8")] = 'b';
        _pieces[Reference.Parse("d8")] = 'q';
        _pieces[Reference.Parse("e8")] = 'k';
    }

    public Board(IEnumerable<KeyValuePair<Reference, char>> pieces)
    {
        _pieces = new(pieces);
    }

    public char? this[Reference reference] => _pieces.TryGetValue(reference, out var piece) ? piece : null;
    private char? this[int index] => this[new Reference(index)];

    public IEnumerator<char> GetEnumerator()
        => Enumerable.Range(0, 64).Select(x => this[x] ?? '-').GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Board Move(string move)
    {
        move = move.ToLower();
        if (!Regex.IsMatch(move, "^([a-h][1-8]){2}$"))
        {
            throw new InvalidMoveException(move);
        }

        var (from, to) = (Reference.Parse(move[..2]), Reference.Parse(move[2..]));

        var piece = this[from] ?? throw new PieceNotFoundException(from);

        return char.IsUpper(piece)
            ? new Board(
                _pieces
                    .Where(kv => kv.Key != from)
                    .Append(new(to, piece)))
            : throw new OpposingPieceException(from);
    }
}
