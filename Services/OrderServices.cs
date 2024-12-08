using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        IOrderReposetory orderReposetory;

        public OrderServices(IOrderReposetory IOrderReposetory)
        {
            orderReposetory = IOrderReposetory;
        }
        public async Task<Order> addOrder(Order newOrder)
        {
            return await orderReposetory.addOrder(newOrder);
        }
        public async Task<Order> getOrderById(int id)
        {
            return await orderReposetory.getOrderById(id);
        }
    }
}
