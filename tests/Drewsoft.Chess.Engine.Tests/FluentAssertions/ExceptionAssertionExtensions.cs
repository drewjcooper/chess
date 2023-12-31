﻿using Drewsoft.Chess.Engine.Exceptions;

using FluentAssertions.Execution;
using FluentAssertions.Specialized;

namespace FluentAssertions;

internal static class ExceptionAssertionExtensions
{
    internal static ExceptionAssertions<InvalidMoveException> WithMove(
        this ExceptionAssertions<InvalidMoveException> assertion,
        string expected,
        string? because = null,
        params string[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(assertion.Which.Move == expected)
            .WithExpectation("Expected exception with move {0}{reason}, ", expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("but found {0}.", assertion.Which.Move);

        return assertion;
    }

    internal static ExceptionAssertions<IllegalMoveException> WithMove(
        this ExceptionAssertions<IllegalMoveException> assertion,
        string expected,
        string? because = null,
        params string[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(assertion.Which.Move == expected)
            .WithExpectation("Expected exception with move {0}{reason}, ", expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("but found {0}.", assertion.Which.Move);

        return assertion;
    }

    internal static ExceptionAssertions<PieceNotFoundException> WithPosition(
        this ExceptionAssertions<PieceNotFoundException> assertion,
        string expected,
        string? because = null,
        params string[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(assertion.Which.Position == expected)
            .WithExpectation("Expected exception with position {0}{reason}, ", expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("but found {0}.", assertion.Which.Position);

        return assertion;
    }

    internal static ExceptionAssertions<OpposingPieceException> WithPosition(
        this ExceptionAssertions<OpposingPieceException> assertion,
        string expected,
        string? because = null,
        params string[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(assertion.Which.Position == expected)
            .WithExpectation("Expected exception with position {0}{reason}, ", expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("but found {0}.", assertion.Which.Position);

        return assertion;
    }

    internal static ExceptionAssertions<InvalidReferenceException> WithReference(
        this ExceptionAssertions<InvalidReferenceException> assertion,
        string expected,
        string? because = null,
        params string[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(assertion.Which.Reference == expected)
            .WithExpectation("Expected exception with reference {0}{reason}, ", expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("but found {0}.", assertion.Which.Reference);

        return assertion;
    }
}
