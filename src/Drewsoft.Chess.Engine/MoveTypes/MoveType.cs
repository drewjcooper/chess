using Drewsoft.Chess.Engine.Pieces;

namespace Drewsoft.Chess.Engine.MoveTypes;

internal abstract class MoveType
{
    internal abstract IEnumerable<Reference> GetMovesFrom(Reference from);
}

internal class PawnMoveType : MoveType
{
    private readonly Pawn _pawn;

    public PawnMoveType(Pawn pawn)
    {
        _pawn = pawn;
    }

    internal override IEnumerable<Reference> GetMovesFrom(Reference from)
    {

        throw new NotImplementedException();
    }
}

internal readonly struct Step
{
    internal Step(int fileDelta, int rankDelta)
    {
        FileDelta = fileDelta;
        RankDelta = rankDelta;
    }

    public int FileDelta { get; }
    public int RankDelta { get; }
}