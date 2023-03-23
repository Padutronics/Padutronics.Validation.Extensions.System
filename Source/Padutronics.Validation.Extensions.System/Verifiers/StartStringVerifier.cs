using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class StartStringVerifier : Verifier<string>
{
    private readonly string prefix;

    public StartStringVerifier(string prefix)
    {
        this.prefix = prefix;
    }

    public override VerificationResult Verify(string value)
    {
        return value.StartsWith(prefix)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}