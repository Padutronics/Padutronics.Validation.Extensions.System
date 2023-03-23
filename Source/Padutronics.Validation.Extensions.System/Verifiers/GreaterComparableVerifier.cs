using Padutronics.Extensions.System;
using Padutronics.Validation.Verifiers;
using System;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class GreaterComparableVerifier<T> : Verifier<T>
    where T : IComparable<T>
{
    private readonly T lowerBound;

    public GreaterComparableVerifier(T lowerBound)
    {
        this.lowerBound = lowerBound;
    }

    public override VerificationResult Verify(T value)
    {
        return value.IsGreaterThan(lowerBound)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}