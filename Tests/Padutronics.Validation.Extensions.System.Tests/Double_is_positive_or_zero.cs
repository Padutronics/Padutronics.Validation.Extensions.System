using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Double_is_positive_or_zero
{
    private sealed class ModelValidator : Validator<Model<double>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<double>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.PositiveOrZero()
                .WithMessage("Value must be positive or zero.");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_negative()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<double>(-3.0);

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
        var model = new Model<double>(0.0);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_positive()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<double>(3.0);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }
}