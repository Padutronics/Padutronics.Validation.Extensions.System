﻿using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class DoubleVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, double> @this)
    {
        return @this.LessThan(0.0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, double> @this)
    {
        return @this.LessThanOrEqualTo(0.0);
    }
}