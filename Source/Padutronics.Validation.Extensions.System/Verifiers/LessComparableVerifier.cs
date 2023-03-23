using Padutronics.Extensions.System;
using Padutronics.Validation.Verifiers;
using System;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class LessComparableVerifier<T> : Verifier<T>
    where T : IComparable<T>
{
    private readonly T upperBound;

    public LessComparableVerifier(T upperBound)
    {
        this.upperBound = upperBound;
    }

    public override VerificationResult Verify(T value)
    {
        return value.IsLessThan(upperBound)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}