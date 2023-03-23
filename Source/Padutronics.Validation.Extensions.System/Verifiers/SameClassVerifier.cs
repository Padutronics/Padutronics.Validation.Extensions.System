using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class SameClassVerifier<T> : Verifier<T>
    where T : class
{
    private readonly T expectedInstance;

    public SameClassVerifier(T expectedInstance)
    {
        this.expectedInstance = expectedInstance;
    }

    public override VerificationResult Verify(T value)
    {
        return ReferenceEquals(value, expectedInstance)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}