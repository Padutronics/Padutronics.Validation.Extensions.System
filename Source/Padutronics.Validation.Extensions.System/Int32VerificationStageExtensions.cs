﻿using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class Int32VerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Negative<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, int> @this)
    {
        return @this.LessThan(0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> NegativeOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, int> @this)
    {
        return @this.LessThanOrEqualTo(0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Positive<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, int> @this)
    {
        return @this.GreaterThan(0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> PositiveOrZero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, int> @this)
    {
        return @this.GreaterThanOrEqualTo(0);
    }

    public static IConditionStage<TRuleChainBuilder, TTarget> Zero<TRuleChainBuilder, TTarget>(this IVerificationStage<TRuleChainBuilder, TTarget, int> @this)
    {
        return @this.EqualTo(0);
    }
}