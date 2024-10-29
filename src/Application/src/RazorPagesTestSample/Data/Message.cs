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
        /// The text content of the message, limited to 200 characters.
        /// </value>
        /// <remarks>
        /// This property is required and must be a text data type. 
        /// If the text exceeds 200 characters, an error message will be displayed.
        /// </remarks>
        /// /// /// /// /// /// /// /// /// /// [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
