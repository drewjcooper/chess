using System.Collections;

using Drewsoft.Chess.Engine.Exceptions;
using Drewsoft.Chess.Engine.Pieces;

namespace Drewsoft.Chess.Engine;

public class Board : IEnumerable<char>
{
    private readonly Dictionary<Reference, Piece> _pieces;

    public Board()
    {
        _pieces = new();

        for (char file = 'a'; file <= 'h'; file++)
        {
            _pieces[Reference.Parse($"{file}2")] = Pawn.CreateWhite();
            _pieces[Reference.Parse($"{file}7")] = Pawn.CreateBlack();
        }

        _pieces[Reference.Parse("a1")] = _pieces[Reference.Parse("h1")] = Rook.CreateWhite();
        _pieces[Reference.Parse("b1")] = _pieces[Reference.Parse("g1")] = Knight.CreateWhite();
        _pieces[Reference.Parse("c1")] = _pieces[Reference.Parse("f1")] = Bishop.CreateWhite();
        _pieces[Reference.Parse("d1")] = Queen.CreateWhite();
        _pieces[Reference.Parse("e1")] = King.CreateWhite();

        _pieces[Reference.Parse("a8")] = _pieces[Reference.Parse("h8")] = Rook.CreateBlack();
        _pieces[Reference.Parse("b8")] = _pieces[Reference.Parse("g8")] = Knight.CreateBlack();
        _pieces[Reference.Parse("c8")] = _pieces[Reference.Parse("f8")] = Bishop.CreateBlack();
        _pieces[Reference.Parse("d8")] = Queen.CreateBlack();
        _pieces[Reference.Parse("e8")] = King.CreateBlack();
    }

    internal Board(IEnumerable<KeyValuePair<Reference, Piece>> pieces)
    {
        _pieces = new(pieces);
    }

    public Piece? this[Reference reference] => _pieces.TryGetValue(reference, out var piece) ? piece : null;
    private Piece? this[int index] => this[new Reference(index)];

    public IEnumerator<char> GetEnumerator()
        => Enumerable.Range(0, 64).Select(x => this[x]?.Display ?? '-').GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Board MakeMove(string candidate)
    {
        var move = Move.Parse(candidate);

        var piece = this[move.From] ?? throw new PieceNotFoundException(move.From);

        return piece.Colour == Colour.White
            ? new Board(
                _pieces
                    .Where(kv => kv.Key != move.From)
                    .Append(new(move.To, piece)))
            : throw new OpposingPieceException(move.From);
    }
}
