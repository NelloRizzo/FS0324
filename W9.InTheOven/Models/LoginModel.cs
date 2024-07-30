using System.ComponentModel.DataAnnotations;

namespace W9.InTheOven.Models
{
    /// <summary>
    /// View model per il login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(80)]
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
