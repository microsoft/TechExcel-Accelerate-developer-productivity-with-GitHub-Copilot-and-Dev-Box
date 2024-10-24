using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestSample.Data
{
    #region snippet1
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
            /// <summary>
    /// Gets or sets the content of the message.
    /// </summary>
    /// <remarks>
    /// The message content is limited to 200 characters.
    /// </remarks>
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
