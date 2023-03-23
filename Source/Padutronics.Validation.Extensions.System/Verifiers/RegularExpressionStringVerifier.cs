using Padutronics.Validation.Verifiers;
using System.Text.RegularExpressions;

namespace Padutronics.Validation.Extensions.System.Verifiers;

internal sealed class RegularExpressionStringVerifier : Verifier<string>
{
    private readonly Regex regularExpression;

    public RegularExpressionStringVerifier(string pattern) :
        this(new Regex(pattern))
    {
    }

    public RegularExpressionStringVerifier(Regex regularExpression)
    {
        this.regularExpression = regularExpression;
    }

    public override VerificationResult Verify(string value)
    {
        return regularExpression.IsMatch(value)
            ? VerificationResults.Success
            : VerificationResults.Failure;
    }
}