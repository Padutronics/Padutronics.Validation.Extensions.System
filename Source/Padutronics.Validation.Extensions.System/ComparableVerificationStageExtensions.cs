using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Extensions.System.Verifiers.Adapters;
using Padutronics.Validation.Rules.Building.Fluent;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class ComparableVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue lowerBound)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new GreaterComparableVerifier<TValue>(lowerBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> lowerBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new GreaterComparableVerifier<TValue>(lowerBoundExtractor(target))
            )
        );
    }
}