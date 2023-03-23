using Padutronics.Ranges;
using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;
using Padutronics.Validation.ValueExtractors;
using Padutronics.Validation.Verifiers.Adapters;
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

    public static IConditionStage<TRuleChainBuilder, TTarget> AtLeast<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> lowerBoundExtractor)
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

    public static IConditionStage<TRuleChainBuilder, TTarget> AtMost<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> upperBoundExtractor)
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
        return @this.GreaterThan(new DelegateValueExtractor<TTarget, TValue>(lowerBoundExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> lowerBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new GreaterComparableVerifier<TValue>(lowerBoundExtractor.Extract(target))
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
        return @this.GreaterThanOrEqualTo(new DelegateValueExtractor<TTarget, TValue>(lowerBoundExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> GreaterThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> lowerBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new GreaterOrEqualComparableVerifier<TValue>(lowerBoundExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> InRange<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Range<TValue> range)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new RangeComparableVerifier<TValue>(range));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> InRange<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, Range<TValue>> rangeExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.InRange(new DelegateValueExtractor<TTarget, Range<TValue>>(rangeExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> InRange<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, Range<TValue>> rangeExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new RangeComparableVerifier<TValue>(rangeExtractor.Extract(target))
            )
        );
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> InRange<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue inclusiveLowerBound, TValue inclusiveUpperBound)
        where TValue : IComparable<TValue>
    {
        return InRange(@this, new Range<TValue>(inclusiveLowerBound, inclusiveUpperBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> InRange<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue lowerBound, TValue upperBound, bool isLowerBoundIncluded, bool isUpperBoundIncluded)
        where TValue : IComparable<TValue>
    {
        return InRange(@this, new Range<TValue>(lowerBound, upperBound, isLowerBoundIncluded, isUpperBoundIncluded));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, TValue upperBound)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(new LessComparableVerifier<TValue>(upperBound));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, Func<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.LessThan(new DelegateValueExtractor<TTarget, TValue>(upperBoundExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThan<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new LessComparableVerifier<TValue>(upperBoundExtractor.Extract(target))
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
        return @this.LessThanOrEqualTo(new DelegateValueExtractor<TTarget, TValue>(upperBoundExtractor));
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> LessThanOrEqualTo<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this, IValueExtractor<TTarget, TValue> upperBoundExtractor)
        where TValue : IComparable<TValue>
    {
        return @this.VerifiableBy(
            new VerifierFactoryToVerifierAdapter<TTarget, TValue>(
                target => new LessOrEqualComparableVerifier<TValue>(upperBoundExtractor.Extract(target))
            )
        );
    }
}