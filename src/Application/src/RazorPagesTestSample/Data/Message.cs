using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
    #region snippet1
    /// <summary>
    /// Represents a message entity with a maximum length of 250 characters.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the unique identifier for the message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text of the message.
        /// The text is required and has a maximum length of 250 characters.
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "There's a 250 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}