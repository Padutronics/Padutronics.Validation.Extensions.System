using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class SByteVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, sbyte> @this)
    {
        return @this.LessThan((sbyte)0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, sbyte> @this)
    {
        return @this.LessThanOrEqualTo((sbyte)0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Positive<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, sbyte> @this)
    {
        return @this.GreaterThan((sbyte)0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> PositiveOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, sbyte> @this)
    {
        return @this.GreaterThanOrEqualTo((sbyte)0);
    }
}