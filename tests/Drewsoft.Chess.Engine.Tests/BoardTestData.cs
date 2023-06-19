namespace Drewsoft.Chess.Engine.Tests;

public static class BoardTestData
{
    private const string StandardBlackSideStartingPosition = "rnbqkbnr" +
                                                             "pppppppp" +
                                                             "--------" +
                                                             "--------";

    public static TheoryData<string, string> StandardChessInitialLegalMoves()
        => new()
        {
            {
                "a2a3",
                StandardBlackSideStartingPosition +
                "--------" +
                "P-------" +
                "-PPPPPPP" +
                "RNBQKBNR"
            },
            {
                "b2b3",
                StandardBlackSideStartingPosition +
                "--------" +
                "-P------" +
                "P-PPPPPP" +
                "RNBQKBNR"
            },
            {
                "c2c3",
                StandardBlackSideStartingPosition +
                "--------" +
                "--P-----" +
                "PP-PPPPP" +
                "RNBQKBNR"
            },
            {
                "d2d3",
                StandardBlackSideStartingPosition +
                "--------" +
                "---P----" +
                "PPP-PPPP" +
                "RNBQKBNR"
            },
            {
                "e2e3",
                StandardBlackSideStartingPosition +
                "--------" +
                "----P---" +
                "PPPP-PPP" +
                "RNBQKBNR"
            },
            {
                "f2f3",
                StandardBlackSideStartingPosition +
                "--------" +
                "-----P--" +
                "PPPPP-PP" +
                "RNBQKBNR"
            },
            {
                "g2g3",
                StandardBlackSideStartingPosition +
                "--------" +
                "------P-" +
                "PPPPPP-P" +
                "RNBQKBNR"
            },
            {
                "h2h3",
                StandardBlackSideStartingPosition +
                "--------" +
                "-------P" +
                "PPPPPPP-" +
                "RNBQKBNR"
            },
            {
                "a2a4",
                StandardBlackSideStartingPosition +
                "P-------" +
                "--------" +
                "-PPPPPPP" +
                "RNBQKBNR"
            },
            {
                "b2b4",
                StandardBlackSideStartingPosition +
                "-P------" +
                "--------" +
                "P-PPPPPP" +
                "RNBQKBNR"
            },
            {
                "c2c4",
                StandardBlackSideStartingPosition +
                "--P-----" +
                "--------" +
                "PP-PPPPP" +
                "RNBQKBNR"
            },
            {
                "d2d4",
                StandardBlackSideStartingPosition +
                "---P----" +
                "--------" +
                "PPP-PPPP" +
                "RNBQKBNR"
            },
            {
                "e2e4",
                StandardBlackSideStartingPosition +
                "----P---" +
                "--------" +
                "PPPP-PPP" +
                "RNBQKBNR"
            },
            {
                "f2f4",
                StandardBlackSideStartingPosition +
                "-----P--" +
                "--------" +
                "PPPPP-PP" +
                "RNBQKBNR"
            },
            {
                "g2g4",
                StandardBlackSideStartingPosition +
                "------P-" +
                "--------" +
                "PPPPPP-P" +
                "RNBQKBNR"
            },
            {
                "h2h4",
                StandardBlackSideStartingPosition +
                "-------P" +
                "--------" +
                "PPPPPPP-" +
                "RNBQKBNR"
            },
            {
                "b1a3",
                StandardBlackSideStartingPosition +
                "--------" +
                "N-------" +
                "PPPPPPPP" +
                "R-BQKBNR"
            },
            {
                "b1c3",
                StandardBlackSideStartingPosition +
                "--------" +
                "--N-----" +
                "PPPPPPPP" +
                "R-BQKBNR"
            },
            {
                "g1f3",
                StandardBlackSideStartingPosition +
                "--------" +
                "-----N--" +
                "PPPPPPPP" +
                "RNBQKB-R"
            },
            {
                "g1h3",
                StandardBlackSideStartingPosition +
                "--------" +
                "-------N" +
                "PPPPPPPP" +
                "RNBQKB-R"
            }
        };
}
