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
        /// Calculates the factorial of a given number.
        /// </summary>
        /// <param name="n">The number for which the factorial is to be calculated.</param>
        /// <returns>The factorial of the given number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than 0.</exception>
        [StringLength(200, ErrorMessage = "There's a 200 character limit on messages. Please shorten your message.")]
        public string Text { get; set; }
    }
    #endregion
}
