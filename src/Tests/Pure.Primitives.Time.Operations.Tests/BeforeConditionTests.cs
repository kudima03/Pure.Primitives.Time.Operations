﻿using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Time.Operations.Tests;

public sealed record BeforeConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscending()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(1, 1, 1, 1, 1)),
            new Time(new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(2, 1, 1, 1, 1)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscendingOneSame()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(1, 1, 1, 1, 1)),
            new Time(new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1),
                new UShort(1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(2, 1, 1, 1, 1)),
            new Time(new TimeOnly(2, 1, 1, 1, 1)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnDescending()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(2, 1, 1, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)),
            new Time(new TimeOnly(1, 1, 1, 1, 1)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSame()
    {
        IBool equality = new BeforeCondition(
            new Time(new TimeOnly(2, 1, 1, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new BeforeCondition(new CurrentTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new BeforeCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new BeforeCondition(new RandomTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new BeforeCondition(new RandomTime()).ToString());
    }
}