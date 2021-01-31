using FluentAssertions;
using HealthTech.App;
using HealthTech.App.Interfaces;
using Xunit;

namespace HealthApp.Test
{
    public class ValidatorTest
    {
        private readonly IValidator _validator;
        public ValidatorTest()
        {
            _validator = new Validator();
        }

        [Theory]
        [InlineData("")]
        public void Validate_ValidateDepth_Empty(string depth)
        {
            var result = _validator.IsValid(depth);
            result.Should().BeFalse();
        }
        [Theory]
        [InlineData("-1")]
        public void Validate_ValidateDepth_Negavtive(string depth)
        {
            var result = _validator.IsValid(depth);
            result.Should().BeFalse();
        }


        [Theory]
        [InlineData("2")]
        public void Validate_ValidateDepth_Positive(string depth)
        {
            var result = _validator.IsValid(depth);
            result.Should().BeTrue();
        }
    }
}
