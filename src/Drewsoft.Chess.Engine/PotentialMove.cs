namespace Drewsoft.Chess.Engine;

public record PotentialMove(bool IsCapture)
{
    private readonly Move _move;

    public PotentialMove(Move move, bool isCapture) 
        : this(isCapture)
    {
        _move = move;
    }

    public Reference To => _move.To;
}