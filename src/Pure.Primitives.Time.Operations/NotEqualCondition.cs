﻿using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Time.Operations;

public sealed record NotEqualCondition : IBool
{
    private readonly IEnumerable<ITime> _values;

    public NotEqualCondition(params ITime[] values) : this(values.AsReadOnly()) { }

    public NotEqualCondition(IEnumerable<ITime> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            int distinctCount = _values
                .DistinctBy(x => (x.Hour.NumberValue,
                    x.Minute.NumberValue,
                    x.Second.NumberValue,
                    x.Millisecond.NumberValue,
                    x.Microsecond.NumberValue,
                    x.Nanosecond.NumberValue))
                .Count();

            if (distinctCount == 0)
            {
                throw new ArgumentException();
            }

            return distinctCount > 1;
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