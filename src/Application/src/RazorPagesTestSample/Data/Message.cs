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
        /// The text of the message.
        /// </value>
        /// <remarks>
        /// The message text must be between 1 and 200 characters long.
        /// </remarks>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Thrown when the text does not meet the length requirements.
        /// </exception>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Message Text")]
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        [MinLength(1, ErrorMessage = "The message must be at least 1 character long.")]
        public string Text { get; set; }
    }
    #endregion
}
