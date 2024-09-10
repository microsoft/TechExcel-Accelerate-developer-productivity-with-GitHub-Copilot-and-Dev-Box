using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
    #region snippet1
    public class Message
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        /// <remarks>
        /// The text is required and must be a string with a maximum length of 200 characters.
        /// </remarks>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Thrown when the text exceeds 200 characters.
        /// </exception>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
