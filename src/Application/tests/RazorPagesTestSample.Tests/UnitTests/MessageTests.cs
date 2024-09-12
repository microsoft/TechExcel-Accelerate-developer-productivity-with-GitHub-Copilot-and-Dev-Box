using System.ComponentModel.DataAnnotations;
using RazorPagesTestSample.Data;
using Xunit;

namespace RazorPagesTestSample.Tests.UnitTests
{
    public class MessageTests
    {
        [Fact]
        public void MessageText_ShouldNotExceed250Characters()
        {
            // Arrange
            var message = new Message
            {
                Text = new string('a', 251) // 251 characters
            };
            var validationContext = new ValidationContext(message);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(message, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("250 character limit"));
        }

        [Fact]
        public void MessageText_ShouldBeValid_WhenWithin250Characters()
        {
            // Arrange
            var message = new Message
            {
                Text = new string('a', 250) // 250 characters
            };
            var validationContext = new ValidationContext(message);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(message, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
        }
    }
}