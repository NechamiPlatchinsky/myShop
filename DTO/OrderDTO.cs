using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DTO
{
    public record OrderDTO(int? OrderId, DateTime? OrderDate, double? OrderSum,ICollection<OrderItem> OrderItems,string? UserFirstName,string? UserLastName);
}
