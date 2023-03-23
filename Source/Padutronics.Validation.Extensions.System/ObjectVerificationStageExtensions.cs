using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers.Adapters;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class ObjectVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> EqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue expectedValue)
    {
        return @this.VerifiableBy(new EqualObjectVerifier<TValue>(expectedValue));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> EqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> expectedValueExtractor)
    {
        return @this.EqualTo(new DelegateValueExtractor<TTarget, TValue>(expectedValueExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> EqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> expectedValueExtractor)
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new EqualObjectVerifier<TValue>(expectedValueExtractor.Extract(target))
            )
        );
    }
}