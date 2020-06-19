using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength( 50 )]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression( @"^[1-9]\d{2}-\d{3}-\d{4}" )]
        public string MobileNumber { get; set; }

        public string Notes { get; set; }
    }
}
