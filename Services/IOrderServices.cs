using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> addOrder(Order newOrder);
        Task<Order> getOrderById(int id);
        //changes from tali
    }
}