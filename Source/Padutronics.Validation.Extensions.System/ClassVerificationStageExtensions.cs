using Padutronics.Validation.Extensions.System.Verifiers;
using Padutronics.Validation.Rules.Building.Fluent;

namespace Padutronics.Validation.Extensions.System;

public static class ClassVerificationStageExtensions
{
    public static IConditionStage<TRuleChainBuilder, TTarget> Null<TRuleChainBuilder, TTarget, TValue>(this IVerificationStage<TRuleChainBuilder, TTarget, TValue> @this)
        where TValue : class?
    {
        return @this.VerifiableBy(new NullClassVerifier<TValue>());
    }
}