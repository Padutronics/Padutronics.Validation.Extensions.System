using Padutronics.Extensions.System;
using Padutronics.Validation.Verifiers;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class EmptyStringVerifier : Verifier<string>
{
    public override VerificationResult Verify(string value)
    {
        return value.IsEmpty()
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}