using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    //[Required]
    public int UserId { get; set; }
    [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string FirstName { get; set; } = null!;
    [StringLength(20, ErrorMessage = "Name can be between 2 till 20 letters", MinimumLength = 2), Required]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}



