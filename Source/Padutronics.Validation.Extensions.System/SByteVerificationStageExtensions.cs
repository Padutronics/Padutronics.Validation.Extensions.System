﻿using Padutronics.Validation.Rules.Building.Fluent;

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
}