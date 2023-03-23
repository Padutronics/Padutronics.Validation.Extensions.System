using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Class_is_null
{
    private sealed class ModelValidator : Validator<Model<object?>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<object?>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.Null()
                .WithMessage("Value must be null.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_null()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<object?>(null);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_is_not_null()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<object?>(new object());

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}