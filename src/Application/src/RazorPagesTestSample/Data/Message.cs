using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
    #region snippet1
    public class Message
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        /// <value>
        /// The text content of the message, limited to 300 characters.
        /// </value>
        /// <remarks>
        /// This property is required and must be a text data type. If the text exceeds 300 characters,
        /// an error message will be displayed indicating the character limit.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown when the text exceeds 300 characters or is not provided.
        /// </exception>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(300, ErrorMessage = "There's a 300 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
