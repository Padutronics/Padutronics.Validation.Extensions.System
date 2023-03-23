using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Class_is_same_as
{
    private sealed class ModelValidator : Validator<Model<object>>
    {
        public static object ExpectedInstance { get; } = new object();

        protected override void BuildRuleSet(IRuleSetBuilder<Model<object>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.SameAs(ExpectedInstance)
                .WithMessage("Value must be the same.");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_instance_is_the_same_as_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<object>(ModelValidator.ExpectedInstance);

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_instance_is_not_the_same_as_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<object>(new object());

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}