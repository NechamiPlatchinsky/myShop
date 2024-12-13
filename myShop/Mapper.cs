using AutoMapper;
using Entities;
using DTO;

namespace myShop
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderPostDTO, Order>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<UserDTO, User>();
            CreateMap<User, ReturnUserDTO>();
        }
    }
}
