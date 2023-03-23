using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class ContainStringVerifier : Verifier<string>
{
    private readonly string substring;

    public ContainStringVerifier(string substring)
    {
        this.substring = substring;
    }

    public override VerificationResult Verify(string value)
    {
        return value.Contains(substring)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}