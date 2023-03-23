using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class SingleVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, float> @this)
    {
        return @this.LessThan(0.0F);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, float> @this)
    {
        return @this.LessThanOrEqualTo(0.0F);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Positive<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, float> @this)
    {
        return @this.GreaterThan(0.0F);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> PositiveOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, float> @this)
    {
        return @this.GreaterThanOrEqualTo(0.0F);
    }
}