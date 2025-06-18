using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Time.Operations.Tests;

public sealed record NotBeforeConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new NotBeforeCondition(
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new NotBeforeCondition(
            new Time(new TimeOnly(1, 2, 3, 4, 5)),
            new Time(new TimeOnly(1, 2, 3, 4, 5)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscending()
    {
        IBool equality = new NotBeforeCondition(
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

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDescending()
    {
        IBool equality = new NotBeforeCondition(
            new Time(new TimeOnly(2, 1, 1, 1, 1)),
            new Time(new TimeOnly(1, 2, 1, 1, 1)),
            new Time(new TimeOnly(1, 1, 2, 1, 1)),
            new Time(new TimeOnly(1, 1, 1, 2, 1)),
            new Time(new TimeOnly(1, 1, 1, 1, 2)),
            new Time(new TimeOnly(1, 1, 1, 1, 1)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSame()
    {
        IBool equality = new NotBeforeCondition(
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
        IBool equality = new NotBeforeCondition(new CurrentTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotBeforeCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NotBeforeCondition(new RandomTime()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NotBeforeCondition(new RandomTime()).ToString());
    }
}