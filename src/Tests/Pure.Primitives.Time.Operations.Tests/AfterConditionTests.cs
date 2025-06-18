using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Time.Operations.Tests;

public sealed record AfterConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new AfterCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new AfterCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscending()
    {
        IBool equality = new AfterCondition(
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
    public void TakesPositiveResultOnDescending()
    {
        IBool equality = new AfterCondition(
            new Time(new TimeOnly(2, 1, 1, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSame()
    {
        IBool equality = new AfterCondition(
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
        IBool equality = new AfterCondition(new CurrentTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new AfterCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new AfterCondition(new RandomTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new AfterCondition(new RandomTime()).ToString());
    }
}