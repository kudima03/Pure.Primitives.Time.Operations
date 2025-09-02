using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Time.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new EqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1)))
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new EqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1)))
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition(new RandomTimeCollection(new UShort(10)));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new EqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new RandomTime()
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new EqualCondition(new CurrentTime());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new EqualCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EqualCondition(new RandomTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EqualCondition(new RandomTime()).ToString()
        );
    }
}
