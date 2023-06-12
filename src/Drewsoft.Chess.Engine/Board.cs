namespace Drewsoft.Chess.Engine;

public class Board
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

    public string? this[string reference] => _pieces.GetValueOrDefault(reference, "-");
}
