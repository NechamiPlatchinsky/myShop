using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UserDTO(int UserId, [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,[Required]string Password, [Required] string FirstName, [StringLength(20, ErrorMessage = "Name can be between 2 till 20 letters", MinimumLength = 2), Required] string LastName);
    public record ReturnUserDTO(int UserId,string FirstName,string LastName); 
}
