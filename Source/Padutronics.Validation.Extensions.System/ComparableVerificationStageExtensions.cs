using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Extensions.System.Verifiers.Adapters;
using Padutronics.Validation.Rules.Building.Fluent;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class ComparableVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> AtLeast<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue lowerBound)
        where TValue : IComparable<TValue>
    {
        return @this.GreaterThanOrEqualTo(lowerBound);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> AtLeast<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> lowerBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.GreaterThanOrEqualTo(lowerBoundExtractor);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> AtMost<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue upperBound)
        where TValue : IComparable<TValue>
    {
        return @this.LessThanOrEqualTo(upperBound);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> AtMost<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.LessThanOrEqualTo(upperBoundExtractor);
    }

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

    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue lowerBound)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new GreaterOrEqualComparableVerifier<TValue>(lowerBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> lowerBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new GreaterOrEqualComparableVerifier<TValue>(lowerBoundExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue upperBound)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new LessComparableVerifier<TValue>(upperBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new LessComparableVerifier<TValue>(upperBoundExtractor(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue upperBound)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new LessOrEqualComparableVerifier<TValue>(upperBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new LessOrEqualComparableVerifier<TValue>(upperBoundExtractor(target))
            )
        );
    }
}