using BikeShopAPI.Services.Email;
using FluentAssertions;
using Xunit;

namespace BikeShopAPI.Tests
{
    public class TestEmailValidator
    {
        private readonly EmailValidator _validator;

        public TestEmailValidator()
        {
            _validator = new EmailValidator();
        }

        [Theory]
        [InlineData("cycle86@example.com")]
        [InlineData("f1x1e.rider@example.com")]
        [InlineData("spr0cket@example.com")]
        public void IsValidEmail_Is_True_Given_Valid_Email(string email)
        {
            var result = _validator.IsValidEmail(email);
            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("^__^@example.com")]
        [InlineData(";SELECT")]
        [InlineData(null)]
        public void IsValidEmail_Id_False_Given_Invalid_Email(string email)
        {
            var result = _validator.IsValidEmail(email);
            result.Should().BeFalse();
        }
    }
}