using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class UInt16_is_zero
{
    private sealed class ModelValidator : Validator<Model<ushort>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<ushort>> ruleSetBuilder)
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
        var model = new Model<ushort>(0);

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
        var model = new Model<ushort>(3);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}