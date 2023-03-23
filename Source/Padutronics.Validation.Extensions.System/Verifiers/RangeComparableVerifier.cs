using Padutronics.Ranges;
using Padutronics.Validation.Verifiers;
using System;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class RangeComparableVerifier<T> : Verifier<T>
    where T : IComparable<T>
{
    private readonly Range<T> range;

    public RangeComparableVerifier(Range<T> range)
    {
        this.range = range;
    }

    public override VerificationResult Verify(T value)
    {
        return range.Contains(value)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}