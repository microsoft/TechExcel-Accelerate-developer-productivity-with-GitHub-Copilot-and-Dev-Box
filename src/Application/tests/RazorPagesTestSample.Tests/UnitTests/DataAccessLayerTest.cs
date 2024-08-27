using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using RazorPagesTestSample.Data;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Tests.UnitTests
{
    public class DataAccessLayerTest
    {
        [Fact]
        public async Task GetMessagesAsync_MessagesAreReturned()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(expectedMessages);
                await db.SaveChangesAsync();

                // Act
                var result = await db.GetMessagesAsync();

                // Assert
                var actualMessages = Assert.IsAssignableFrom<List<Message>>(result);
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text), 
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }

        [Fact]
        public async Task AddMessageAsync_MessageIsAdded()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = 10;
                var expectedMessage = new Message() { Id = recId, Text = "Message" };

                // Act
                await db.AddMessageAsync(expectedMessage);

                // Assert
                var actualMessage = await db.FindAsync<Message>(recId);
                Assert.Equal(expectedMessage, actualMessage);
            }
        }

        [Fact]
        public async Task DeleteAllMessagesAsync_MessagesAreDeleted()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(seedMessages);
                await db.SaveChangesAsync();

                // Act
                await db.DeleteAllMessagesAsync();

                // Assert
                Assert.Empty(await db.Messages.AsNoTracking().ToListAsync());
            }
        }

        [Fact]
        public async Task DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                #region snippet1
                // Arrange
                var seedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(seedMessages);
                await db.SaveChangesAsync();
                var recId = 1;
                var expectedMessages = 
                    seedMessages.Where(message => message.Id != recId).ToList();
                #endregion

                #region snippet2
                // Act
                await db.DeleteMessageAsync(recId);
                #endregion

                #region snippet3
                // Assert
                var actualMessages = await db.Messages.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text), 
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
                #endregion
            }
        }

        #region snippet4
        [Fact]
        public async Task DeleteMessageAsync_NoMessageIsDeleted_WhenMessageIsNotFound()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(expectedMessages);
                await db.SaveChangesAsync();
                var recId = 4;

                // Act
                try
                {
                    await db.DeleteMessageAsync(recId);
                }
                catch
                {
                    // recId doesn't exist
                }

                // Assert
                var actualMessages = await db.Messages.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text), 
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }
        #endregion

        #region snippet5
        [Theory]
        [InlineData(150, true)]
        [InlineData(199, true)]
        [InlineData(200, true)]
        [InlineData(201, true)]
        [InlineData(249, true)]
        [InlineData(250, true)]
        [InlineData(251, false)]
        [InlineData(300, false)]
        public void Message_LengthValidation(int length, bool isValid)
        {
            // Arrange
            var message = new Message
            {
                Id = 1,
                Text = new string('a', length)
            };

            // Act
            var validationResults = ValidateModel(message);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                Assert.NotEmpty(validationResults);
                Assert.Contains(validationResults, v => v.ErrorMessage.Contains("250 character limit"));
            }
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
        #endregion
    }
}
