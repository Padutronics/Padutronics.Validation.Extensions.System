using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class EndStringVerifier : Verifier<string>
{
    private readonly string suffix;

    public EndStringVerifier(string suffix)
    {
        this.suffix = suffix;
    }

    public override VerificationResult Verify(string value)
    {
        return value.EndsWith(suffix)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}