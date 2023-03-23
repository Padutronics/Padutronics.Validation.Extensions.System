using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Boolean_is_false
{
    private sealed class ModelValidator : Validator<Model<bool>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<bool>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.False()
                .WithMessage("Value must be false.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_false()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<bool>(false);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_true()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<bool>(true);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}