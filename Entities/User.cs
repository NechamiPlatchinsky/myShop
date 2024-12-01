using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }
    [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"),Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string FirstName { get; set; } = null!;
    [StringLength(20,ErrorMessage ="lastName can be between 2 till 20 letter",MinimumLength =2)]
    public string LastName { get; set; } = null!;
}
