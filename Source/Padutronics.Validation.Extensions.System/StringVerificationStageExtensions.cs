using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers.Adapters;
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
        return @this.Contain(new DelegateValueExtractor<TTarget, string>(substringExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Contain<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, IValueExtractor<TTarget, string> substringExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new ContainStringVerifier(substringExtractor.Extract(target))
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
        return @this.EndWith(new DelegateValueExtractor<TTarget, string>(suffixExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> EndWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, IValueExtractor<TTarget, string> suffixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new EndStringVerifier(suffixExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Match<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string pattern)
    {
        return @this.VerifiableBy(new RegularExpressionStringVerifier(pattern));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Match<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> patternExtractor)
    {
        return @this.Match(new DelegateValueExtractor<TTarget, string>(patternExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Match<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, IValueExtractor<TTarget, string> patternExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new RegularExpressionStringVerifier(patternExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> StartWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, string prefix)
    {
        return @this.VerifiableBy(new StartStringVerifier(prefix));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> StartWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, Func<TTarget, string> prefixExtractor)
    {
        return @this.StartWith(new DelegateValueExtractor<TTarget, string>(prefixExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> StartWith<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this, IValueExtractor<TTarget, string> prefixExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, string>(
                target => new StartStringVerifier(prefixExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> WhiteSpace<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, string> @this)
    {
        return @this.VerifiableBy(new WhiteSpaceStringVerifier());
    }
}