using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Int16_is_positive
{
    private sealed class ModelValidator : Validator<Model<short>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<short>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.Positive()
                .WithMessage("Value must be positive.");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_negative()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<short>(-3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_failed_if_value_is_zero()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<short>(0);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_positive()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<short>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }
}