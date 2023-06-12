using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class BoardTests
{
    [Theory]
    [ClassData(typeof(DefaultChessGameTestData))]
    public void Board_Ctor_Parameterless_InitialisesDefaultGame(string reference, string expected)
    {
        var sut = new Board();

        var result = sut[reference];

        result.Should().Be(expected);
    }

}
