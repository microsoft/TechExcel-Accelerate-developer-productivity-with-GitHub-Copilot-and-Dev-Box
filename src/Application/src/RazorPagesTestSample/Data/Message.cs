using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
    #region snippet1
    public class Message
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text message.
        /// </summary>
        /// <value>
        /// The text message.
        /// </value>
        /// <remarks>
        /// The message is required and must be a text with a maximum length of 200 characters.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown when the text message exceeds the 200 character limit.
        /// </exception>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
