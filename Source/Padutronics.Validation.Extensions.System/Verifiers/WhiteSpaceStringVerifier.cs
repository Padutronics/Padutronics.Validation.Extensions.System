using Padutronics.Extensions.System;
using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class WhiteSpaceStringVerifier : Verifier<string>
{
    public override VerificationResult Verify(string value)
    {
        return value.IsWhiteSpace()
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}