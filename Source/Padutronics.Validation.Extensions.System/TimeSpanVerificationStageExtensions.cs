using Padutronics.Validation.Rules.Building.Fluent;
using System;

namespace Padutronics.Validation.Extensions.System;

public static class TimeSpanVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, TimeSpan> @this)
    {
        return @this.LessThan(TimeSpan.Zero);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, TimeSpan> @this)
    {
        return @this.LessThanOrEqualTo(TimeSpan.Zero);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Positive<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, TimeSpan> @this)
    {
        return @this.GreaterThan(TimeSpan.Zero);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> PositiveOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, TimeSpan> @this)
    {
        return @this.GreaterThanOrEqualTo(TimeSpan.Zero);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Zero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, TimeSpan> @this)
    {
        return @this.EqualTo(TimeSpan.Zero);
    }
}