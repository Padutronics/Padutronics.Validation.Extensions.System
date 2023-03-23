using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class UInt64VerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Zero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, ulong> @this)
    {
        return @this.EqualTo(0UL);
    }
}