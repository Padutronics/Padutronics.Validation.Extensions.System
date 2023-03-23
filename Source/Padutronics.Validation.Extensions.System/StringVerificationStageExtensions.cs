using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Extensions.System.Verifiers.Adapters;
using Padutronics.Validation.Rules.Building.Fluent;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class StringVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string substring)
    {
        return @this.VerifiableBy(new ContainStringVerifier(substring));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> substringExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new ContainStringVerifier(substringExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Empty<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this)
    {
        return @this.VerifiableBy(new EmptyStringVerifier());
    }
}