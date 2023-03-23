using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class BooleanVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> False<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, bool> @this)
    {
        return @this.EqualTo(false);
    }
}