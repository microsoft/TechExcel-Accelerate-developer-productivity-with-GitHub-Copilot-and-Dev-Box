using System.ComponentModel.DataAnnotations;
using RazorPagesTestSample.Data;
using Xunit;
using System.Collections.Generic;

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

        //test the insertion of a message of length 150
        [Fact]
        public void MessageText_ShouldBeValid_WhenWithin150Characters()
        {
            // Arrange
            var message = new Message
            {
                Text = new string('a', 150) // 150 characters
            };
            var validationContext = new ValidationContext(message);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(message, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
        }

        //test a message of length 249
        [Fact]
        public void MessageText_ShouldBeValid_WhenWithin249Characters()
        {
            // Arrange
            var message = new Message
            {
                Text = new string('a', 249) // 249 characters
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