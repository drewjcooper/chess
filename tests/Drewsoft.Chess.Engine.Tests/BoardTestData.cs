namespace Drewsoft.Chess.Engine;

public static class BoardTestData
{
    public static TheoryData<string, string> TryParseFenPositiveCases()
        => new()
        {
            {
                "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1",
                "rnbqkbnr" +
                "pppppppp" +
                "--------" +
                "--------" +
                "--------" +
                "--------" +
                "PPPPPPPP" +
                "RNBQKBNR"
            }
        };

    public static TheoryData<string> TryParseToStringRoundTripCases()
        => new()
        {
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
        };
}