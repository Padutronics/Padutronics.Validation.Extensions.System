using Padutronics.Validation.Verifiers;
using System;
using System.Threading.Tasks;

namespace Padutronics.Validation.Extensions.System.Verifiers.Adapters;

internal sealed class VerifierFactoryToVerifierAdapter<TTarget, TValue> : IVerifier<TTarget, TValue>
{
    private readonly Func<TTarget, IVerifier<TValue>> verifierFactory;

    public VerifierFactoryToVerifierAdapter(Func<TTarget, IVerifier<TValue>> verifierFactory)
    {
        this.verifierFactory = verifierFactory;
    }

    public VerificationResult Verify(TTarget target, TValue value)
    {
        IVerifier<TValue> verifier = verifierFactory(target);

        return verifier.Verify(value);
    }

    public Task<VerificationResult> VerifyAsync(TTarget target, TValue value)
    {
        IVerifier<TValue> verifier = verifierFactory(target);

        return verifier.VerifyAsync(value);
    }
}