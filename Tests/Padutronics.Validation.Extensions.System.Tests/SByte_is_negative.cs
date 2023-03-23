using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class SByte_is_negative
{
    private sealed class ModelValidator : Validator<Model<sbyte>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<sbyte>> ruleSetBuilder)
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
        var model = new Model<sbyte>(-3);

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
        var model = new Model<sbyte>(0);

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
        var model = new Model<sbyte>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}