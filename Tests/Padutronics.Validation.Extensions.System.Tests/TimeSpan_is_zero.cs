using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;
using System;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class TimeSpan_is_zero
{
    private sealed class ModelValidator : Validator<Model<TimeSpan>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<TimeSpan>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.Zero()
                .WithMessage("Value must be zero.");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_negative()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<TimeSpan>(TimeSpan.FromSeconds(-3.0));

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_zero()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<TimeSpan>(TimeSpan.Zero);

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
        var model = new Model<TimeSpan>(TimeSpan.FromSeconds(3.0));

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}