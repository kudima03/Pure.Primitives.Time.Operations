using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Time.Operations;

public sealed record NotEqualCondition : IBool
{
    private readonly IEnumerable<ITime> _values;

    public NotEqualCondition(params IEnumerable<ITime> values)
    {
        _values = values;
    }

    public bool BoolValue
    {
        get
        {
            int distinctCount = _values
                .DistinctBy(x =>
                    (
                        x.Hour.NumberValue,
                        x.Minute.NumberValue,
                        x.Second.NumberValue,
                        x.Millisecond.NumberValue,
                        x.Microsecond.NumberValue,
                        x.Nanosecond.NumberValue
                    )
                )
                .Count();

            return distinctCount == 0 ? throw new ArgumentException() : distinctCount > 1;
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
