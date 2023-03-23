using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class UInt16VerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Zero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, ushort> @this)
    {
        return @this.EqualTo((ushort)0);
    }
}