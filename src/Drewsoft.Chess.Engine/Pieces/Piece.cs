namespace Drewsoft.Chess.Engine.Pieces;

public abstract class Piece
{
    protected Piece(Colour colour, char display)
    {
        Colour = colour;
        Display = colour == Colour.White ? char.ToUpper(display) : char.ToLower(display); ;
    }

    public Colour Colour { get; }
    public char Display { get; }
}

internal class Pawn : Piece
{
    private Pawn(Colour colour)
        : base(colour, 'P')
    {
    }

    public static Pawn CreateWhite() => new(Colour.White);
    public static Pawn CreateBlack() => new(Colour.Black);
}

internal class Rook : Piece
{
    private Rook(Colour colour)
        : base(colour, 'R')
    {
    }

    public static Rook CreateWhite() => new(Colour.White);
    public static Rook CreateBlack() => new(Colour.Black);
}

internal class Knight : Piece
{
    private Knight(Colour colour)
        : base(colour, 'N')
    {
    }

    public static Knight CreateWhite() => new(Colour.White);
    public static Knight CreateBlack() => new(Colour.Black);
}

internal class Bishop : Piece
{
    private Bishop(Colour colour)
        : base(colour, 'B')
    {
    }

    public static Bishop CreateWhite() => new(Colour.White);
    public static Bishop CreateBlack() => new(Colour.Black);
}

internal class Queen : Piece
{
    private Queen(Colour colour)
        : base(colour, 'Q')
    {
    }

    public static Queen CreateWhite() => new(Colour.White);
    public static Queen CreateBlack() => new(Colour.Black);
}

internal class King : Piece
{
    private King(Colour colour)
        : base(colour, 'K')
    {
    }

    public static King CreateWhite() => new(Colour.White);
    public static King CreateBlack() => new(Colour.Black);
}

public enum Colour
{
    White,
    Black
}