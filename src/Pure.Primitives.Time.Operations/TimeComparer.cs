using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Time.Operations;

internal sealed record TimeComparer : IComparer<ITime>
{
    public int Compare(ITime? first, ITime? second)
    {
        int result = first!.Hour.NumberValue.CompareTo(second!.Hour.NumberValue);

        if (result != 0)
        {
            return result;
        }

        result = first.Minute.NumberValue.CompareTo(second.Minute.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Second.NumberValue.CompareTo(second.Second.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Millisecond.NumberValue.CompareTo(second.Millisecond.NumberValue);
        if (result != 0)
        {
            return result;
        }

        result = first.Microsecond.NumberValue.CompareTo(second.Microsecond.NumberValue);
        if (result != 0)
        {
            return result;
        }

        return first.Nanosecond.NumberValue.CompareTo(second.Nanosecond.NumberValue);
    }
}