using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [StringLength(20,ErrorMessage ="Name can be between 2 till 20 letters",MinimumLength =2),Required]
        public string LastName { get; set; }

        public int UserId { get; set; }
    }
}
