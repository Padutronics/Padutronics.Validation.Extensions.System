using Padutronics.Extensions.System;
using Padutronics.Validation.Verifiers;
using System;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class GreaterOrEqualComparableVerifier<T> : Verifier<T>
    where T : IComparable<T>
{
    private readonly T lowerBound;

    public GreaterOrEqualComparableVerifier(T lowerBound)
    {
        this.lowerBound = lowerBound;
    }

    public override VerificationResult Verify(T value)
    {
        return value.IsGreaterThanOrEqualTo(lowerBound)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}