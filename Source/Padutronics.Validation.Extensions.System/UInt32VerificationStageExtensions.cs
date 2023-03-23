using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class UInt32VerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Zero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, uint> @this)
    {
        return @this.EqualTo(0U);
    }
}