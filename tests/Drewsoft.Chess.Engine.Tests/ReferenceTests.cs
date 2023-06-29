﻿using FluentAssertions;

namespace Drewsoft.Chess.Engine;

public class ReferenceTests
{
    [Fact]
    public void Reference_Default_Isa8()
    {
        var expected = Reference.Parse("a8");

        Reference sut = default;

        sut.Should().Be(expected);
    }

    [Theory]
    [InlineData("a8", 0)]
    [InlineData("a7", 8)]
    [InlineData("a6", 16)]
    [InlineData("a5", 24)]
    [InlineData("a4", 32)]
    [InlineData("a3", 40)]
    [InlineData("a2", 48)]
    [InlineData("a1", 56)]
    [InlineData("b1", 57)]
    [InlineData("c1", 58)]
    [InlineData("d1", 59)]
    [InlineData("e1", 60)]
    [InlineData("f1", 61)]
    [InlineData("g1", 62)]
    [InlineData("h1", 63)]
    public void Parse_CandidateValid_ReturnsExpectedReference(string candidate, int expectedValue)
    {
        var expected = new Reference(expectedValue);

        var result = Reference.Parse(candidate);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("a8")]
    [InlineData("a7")]
    [InlineData("a6")]
    [InlineData("a5")]
    [InlineData("a4")]
    [InlineData("a3")]
    [InlineData("a2")]
    [InlineData("a1")]
    [InlineData("b1")]
    [InlineData("c1")]
    [InlineData("d1")]
    [InlineData("e1")]
    [InlineData("f1")]
    [InlineData("g1")]
    [InlineData("h1")]
    public void ToString_AfterParse_ReturnsInitialString(string candidate)
    {
        var sut = Reference.Parse(candidate);

        var result = sut.ToString();

        result.Should().Be(candidate);
    }
}
