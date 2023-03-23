using NUnit.Framework;
using Padutronics.Validation.Extensions.System.Tests.Stubs.Models;
using Padutronics.Validation.Rules.Building;
using System;

namespace Padutronics.Validation.Extensions.System.Tests;

[TestFixture]
internal sealed class Object_is_equal_to
{
    private sealed class Property
    {
        private readonly int value;

        public Property(int value)
        {
            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Property);
        }

        public bool Equals(Property? other)
        {
            return other is not null && value == other.value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value);
        }

        public static bool operator ==(Property? left, Property? right)
        {
            return left?.Equals(right) ?? right is null;
        }

        public static bool operator !=(Property? left, Property? right)
        {
            return !(left == right);
        }
    }

    private sealed class ModelValidator : Validator<Model<Property>>
    {
        protected override void BuildRuleSet(IRuleSetBuilder<Model<Property>> ruleSetBuilder)
        {
            ruleSetBuilder.Property(model => model.Value)
                .Is.EqualTo(new Property(3))
                .WithMessage("Value must be equal to 3.");
        }
    }

    [Test]
    public void Validation_is_failed_if_value_is_not_equal_to_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<Property>(new Property(2));

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.False);
    }

    [Test]
    public void Validation_is_succeeded_if_value_is_equal_to_specified()
    {
        // Arrange.
        var validator = new ModelValidator();
        var model = new Model<Property>(new Property(3));

        // Act.
        ValidationResult result = validator.Validate(model);

        // Assert.
        Assert.That(result.IsSucceeded, Is.True);
    }
}