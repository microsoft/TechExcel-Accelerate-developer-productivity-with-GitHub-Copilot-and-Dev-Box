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
        /// The text content of the message, limited to 250 characters.
        /// </value>
        /// <remarks>
        /// The text must be a valid string and is required. If the text exceeds 250 characters, an error message will be displayed.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown when the text exceeds 250 characters or  is not provided.
        /// </exception>
        /// /// /// /// /// /// /// /// /// /// /// /// [Required]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "There's a 250 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
