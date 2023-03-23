using Padutronics.Validation.Verifiers;
using System.Collections.Generic;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class EqualObjectVerifier<T> : Verifier<T>
{
    private readonly T expectedValue;

    public EqualObjectVerifier(T expectedValue)
    {
        this.expectedValue = expectedValue;
    }

    public override VerificationResult Verify(T value)
    {
        return EqualityComparer<T>.Default.Equals(value, expectedValue)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}