using Entities;

namespace Reposetories
{
    public interface IOrderReposetory
    {
        Task<Order> addOrder(Order newOrder);
        Task<Order> getOrderById(int id);
    }
}