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
        [InlineData("", "")]

        public void Validate_ValidateDepth_Empty(string depth, string predicatedIndex)
        {
            var result = _validator.IsValid(depth, predicatedIndex);
            result.Should().BeNull();
        }
        [Theory]
        [InlineData("-1", "-1")]
        public void Validate_ValidateDepth_Negavtive(string depth, string predicatedIndex)
        {
            var result = _validator.IsValid(depth, predicatedIndex);
            result.Should().BeNull();
        }


        [Theory]
        [InlineData("2", "3")]
        public void Validate_ValidateDepth_Positive(string depth, string predicatedIndex)
        {
            var result = _validator.IsValid(depth, predicatedIndex);
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
        }
    }
}
