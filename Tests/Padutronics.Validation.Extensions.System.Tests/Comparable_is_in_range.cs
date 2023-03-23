﻿using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Comparable_is_in_range
{
    private sealed class ModelValidator : Validator<Model<int>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<int>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.InRange(2, 4)
                .WithMessage("Value must be in range [2, 4].");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_less_than_lower_bound()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(1);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_equal_to_lower_bound()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(2);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_greater_than_lower_bound_and_less_than_upper_bound()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_equal_to_upper_bound()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(4);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_greater_than_upper_bound()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(5);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}