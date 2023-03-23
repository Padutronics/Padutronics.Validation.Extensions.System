using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class Int16VerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, short> @this)
    {
        return @this.LessThan((short)0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, short> @this)
    {
        return @this.LessThanOrEqualTo((short)0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Positive<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, short> @this)
    {
        return @this.GreaterThan((short)0);
    }
}