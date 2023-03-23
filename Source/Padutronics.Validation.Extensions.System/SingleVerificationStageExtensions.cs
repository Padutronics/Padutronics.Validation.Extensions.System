using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class SingleVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, float> @this)
    {
        return @this.LessThan(0.0F);
    }
}