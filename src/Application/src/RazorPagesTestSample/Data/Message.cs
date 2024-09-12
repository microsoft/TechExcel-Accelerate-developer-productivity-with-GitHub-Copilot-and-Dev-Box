using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a message entity with an ID and text content.
/// </summary>
namespace RazorPagesTestSample
{
    public class Message
    {
        /// <summary>
        /// Gets or sets the unique identifier for the message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text content of the message.
        /// </summary>
        /// <remarks>
        /// The text content is required and must be a string with a maximum length of 250 characters.
        /// </remarks>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "There's a 250 character limit on messages. Please shorten your messages.")]
        public string Text { get; set; }
    }

}