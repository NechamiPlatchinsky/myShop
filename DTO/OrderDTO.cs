using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DTO
{
    public record OrderDTO( DateTime? OrderDate, double? OrderSum,ICollection<OrderItem> OrderItems,string? UserFirstName,string? UserLastName);
    public record OrderPostDTO( int? UserId, DateTime? OrderDate, double? OrderSum, ICollection<OrderItemDTO> OrderItems, string? UserFirstName,string? UserLastName);
    public record OrderNewDTO(int? OrderId, DateTime? OrderDate, string UserFirstName, double? OrderSum);
}
