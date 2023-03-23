using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Int32_is_negative
{
    private sealed class ModelValidator : Validator<Model<int>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<int>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.Negative()
                .WithMessage("Value must be negative.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_negative()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(-3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_zero()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(0);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_failed_if_value_is_positive()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<int>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}