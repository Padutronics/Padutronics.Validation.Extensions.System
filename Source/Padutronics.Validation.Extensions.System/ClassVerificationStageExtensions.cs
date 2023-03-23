using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers.Adapters;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class ClassVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Null<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this)
        where TValue : class?
    {
        return @this.VerifiableBy(new NullClassVerifier<TValue>());
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> SameAs<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue expectedInstance)
        where TValue : class
    {
        return @this.VerifiableBy(new SameClassVerifier<TValue>(expectedInstance));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> SameAs<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> expectedInstanceExtractor)
        where TValue : class
    {
        return @this.SameAs(new DelegateValueExtractor<TTarget, TValue>(expectedInstanceExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> SameAs<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> expectedInstanceExtractor)
        where TValue : class
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new SameClassVerifier<TValue>(expectedInstanceExtractor.Extract(target))
            )
        );
    }
}