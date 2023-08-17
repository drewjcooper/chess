namespace Drewsoft.Chess.Engine;

internal class DefaultChessGameTestData : TheoryData<Reference, char?>
{
    public DefaultChessGameTestData()
    {
        AddRearPieces('1', Colour.White);
        AddPawns('2', Colour.White);
        AddEmptyRows('3', '4', '5', '6');
        AddPawns('7', Colour.Black);
        AddRearPieces('8', Colour.Black);
    }

    private void AddRearPieces(char rank, Colour colour)
    {
        AddPiece('a', 'R');
        AddPiece('b', 'N');
        AddPiece('c', 'B');
        AddPiece('d', 'Q');
        AddPiece('e', 'K');
        AddPiece('f', 'B');
        AddPiece('g', 'N');
        AddPiece('h', 'R');

        void AddPiece(char file, char name)
            => Add(Reference.Parse($"{file}{rank}"), colour == Colour.White ? name : char.ToLower(name));
    }

    private void AddPawns(char rank, Colour colour)
    {
        var piece = colour == Colour.White ? 'P' : 'p';
        for (char file = 'a'; file <= 'h'; file++)
        {
            Add(Reference.Parse($"{file}{rank}"), piece);
        }
    }

    private void AddEmptyRows(params char[] ranks)
    {
        foreach (var rank in ranks)
        {
            for (char file = 'a'; file <= 'h'; file++)
            {
                Add(Reference.Parse($"{file}{rank}"), null);
            }
        }
    }
}
