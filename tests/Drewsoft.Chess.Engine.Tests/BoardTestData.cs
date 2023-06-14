namespace Drewsoft.Chess.Engine;

public static class BoardTestData
{
    public static TheoryData<string, string> TryParseXFenPositiveCases()
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
            },
            {
                "qrnkrbbn/pppppppp/8/8/8/8/PPPPPPPP/QRNKRBBN w KQkq - 0 1",
                "qrnkrbbn" +
                "pppppppp" +
                "--------" +
                "--------" +
                "--------" +
                "--------" +
                "PPPPPPPP" +
                "QRNKRBBN"
            },
            {
                "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1",
                "rnbqkbnr" +
                "pppppppp" +
                "--------" +
                "--------" +
                "----P---" +
                "--------" +
                "PPPP-PPP" +
                "RNBQKBNR"
            },
            {
                "r1b1k1nr/p2p1pNp/n2B4/1p1NP2P/6P1/3P1Q2/P1P1K3/q5b1 w KQkq - 0 1",
                "r-bk---r" +
                "p--pBpNp" +
                "n----n--" +
                "-p-NP--P" +
                "------P-" +
                "---P----" +
                "P-P-K---" +
                "q-----b-"
            },
            {
                "8/8/8/4p1K1/2k1P3/8/8/8 b - - 0 1",
                "--------" +
                "--------" +
                "--------" +
                "----p-K-" +
                "--k-P---" +
                "--------" +
                "--------" +
                "--------"
            },
            {
                "4k2r/6r1/8/8/8/8/3R4/R3K3 w Qk - 0 1",
                "----k--r" +
                "------r-" +
                "--------" +
                "--------" +
                "--------" +
                "--------" +
                "---R----" +
                "R---K---"
            },
            {
                "8/5k2/3p4/1p1Pp2p/pP2Pp1P/P4P1K/8/8 b - - 99 50",
                "--------" +
                "-----k--" +
                "---p----" +
                "-p-Pp--p" +
                "pP--P--P" +
                "P----P-K" +
                "--------" +
                "--------"
            },
        };

    public static TheoryData<string> TryParseToStringRoundTripCases()
        => new()
        {
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1",
            "r1b1k1nr/p2p1pNp/n2B4/1p1NP2P/6P1/3P1Q2/P1P1K3/q5b1 w KQkq - 0 1",
            "8/8/8/4p1K1/2k1P3/8/8/8 b - - 0 1",
            "4k2r/6r1/8/8/8/8/3R4/R3K3 w Qk - 0 1",
            "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1",
            "8/5k2/3p4/1p1Pp2p/pP2Pp1P/P4P1K/8/8 b - - 99 50"
        };
}