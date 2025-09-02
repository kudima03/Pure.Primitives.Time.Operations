using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Time.Operations;

public sealed record AfterCondition : IBool
{
    private readonly IEnumerable<ITime> _values;

    public AfterCondition(params IEnumerable<ITime> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            using IEnumerator<ITime> enumerator = _values.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new ArgumentException();
            }

            IComparer<ITime> comparer = new TimeComparer();

            ITime previous = enumerator.Current;

            while (enumerator.MoveNext())
            {
                if (comparer.Compare(previous, enumerator.Current) >= 0)
                {
                    return false;
                }

                previous = enumerator.Current;
            }

            return true;
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
