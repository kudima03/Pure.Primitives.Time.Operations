using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Time.Operations.Tests;

public sealed record NotEqualConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new NotEqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1)))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnTwoSameValues()
    {
        IBool equality = new NotEqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1)))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnDifferentValues()
    {
        IBool equality = new NotEqualCondition(new RandomTimeCollection(new UShort(10)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllSameOneDifferentValue()
    {
        IBool equality = new NotEqualCondition(
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new Time(TimeOnly.FromTimeSpan(new TimeSpan(1, 1, 1))),
            new RandomTime()
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ProduceFalseOnSingleElementInCollection()
    {
        IBool equality = new NotEqualCondition(new CurrentTime());
        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotEqualCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NotEqualCondition(new RandomTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NotEqualCondition(new RandomTime()).ToString()
        );
    }
}
