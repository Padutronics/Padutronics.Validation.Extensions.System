using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class String_does_start_with
{
    private sealed class ModelValidator : Validator<Model<string>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<string>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Does.StartWith("Hel")
                .WithMessage("Value must start with 'Hel'");
        }
    }

    [Test]
    public void Validation_is_succeeded_if_value_starts_with_specified_substring()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<string>("Hello");

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public void Validation_is_failed_if_value_does_not_start_with_specified_substring()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<string>("World");

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }
}