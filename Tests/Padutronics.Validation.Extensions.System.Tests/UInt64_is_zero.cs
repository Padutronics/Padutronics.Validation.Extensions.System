﻿using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class UInt64_is_zero
{
    private sealed class ModelValidator : Validator<Model<ulong>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<ulong>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.Zero()
                .WithMessage("Value must be zero.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_zero()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<ulong>(0UL);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_positive()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<ulong>(3UL);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}