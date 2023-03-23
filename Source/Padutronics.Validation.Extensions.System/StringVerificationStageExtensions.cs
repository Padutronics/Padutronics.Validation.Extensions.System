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

    public static IConditionStage<TRuleChainBuilder, TTarget> EndWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string suffix)
    {
        return @this.VerifiableBy(new EndStringVerifier(suffix));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> EndWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> suffixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new EndStringVerifier(suffixExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Match<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string pattern)
    {
        return @this.VerifiableBy(new RegularExpressionStringVerifier(pattern));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Match<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> patternExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new RegularExpressionStringVerifier(patternExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> StartWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string prefix)
    {
        return @this.VerifiableBy(new StartStringVerifier(prefix));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> StartWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> prefixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new StartStringVerifier(prefixExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> WhiteSpace<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this)
    {
        return @this.VerifiableBy(new WhiteSpaceStringVerifier());
    }
}