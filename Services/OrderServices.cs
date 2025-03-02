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
        IProductReposetory productReposetory;

        public OrderServices(IOrderReposetory IOrderReposetory,IProductReposetory IProductReposetory)
        {
            orderReposetory = IOrderReposetory;
            productReposetory= IProductReposetory;
        }
        public async Task<Order> addOrder(Order newOrder)
        {
            newOrder.OrderSum = await CheckOrserSum(newOrder);
            return await orderReposetory.addOrder(newOrder);
        }
        public async Task<Order> getOrderById(int id)
        {
            return await orderReposetory.getOrderById(id);
        }
        private async Task<double> CheckOrserSum(Order newOrder)
        {
            double realOrderSum = 0.0;
            foreach (var product in newOrder.OrderItems)
            {
                Product p = await productReposetory.getProductById(Convert.ToInt32(product.ProductId));
                realOrderSum += (double)p.Price * (double)product.Quantity;
            }
            return realOrderSum;
        }
    }
}
