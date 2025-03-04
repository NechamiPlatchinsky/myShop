using Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
        private readonly ILogger<OrderServices> _logger;

        public OrderServices(IOrderReposetory IOrderReposetory,IProductReposetory IProductReposetory, ILogger<OrderServices> logger)
        {
            orderReposetory = IOrderReposetory;
            productReposetory= IProductReposetory;
            _logger = logger;
        }
        public async Task<Order> addOrder(Order newOrder)
        {
            double orderSum = await CheckOrserSum(newOrder);
            if (orderSum != newOrder.OrderSum) 
            { 
                newOrder.OrderSum = orderSum;
                _logger.LogCritical($"User with Id: {newOrder.UserId} change the order sum");
            }
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
                realOrderSum += (double)p.Price *  (double)product.Quantity;
            }
            return realOrderSum;
        }
    }
}
