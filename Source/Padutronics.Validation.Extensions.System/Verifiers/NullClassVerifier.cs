using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class NullClassVerifier<T> : Verifier<T>
    where T : class?
{
    public override VerificationResult Verify(T value)
    {
        return value is null
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}