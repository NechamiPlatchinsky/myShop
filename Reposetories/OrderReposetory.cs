using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class OrderReposetory : IOrderReposetory
    {
        _214416448WebApiContext orderContext;

        public OrderReposetory(_214416448WebApiContext _214416448WebApiContext)
        {
            orderContext = _214416448WebApiContext;
        }
        public async Task<Order> addOrder(Order newOrder)
        {
            await orderContext.Orders.AddAsync(newOrder);
            await orderContext.SaveChangesAsync();
            return newOrder;
        }
        public async Task<Order> getOrderById(int id)
        {
            return await orderContext.Orders.Include(o=>o.User).FirstOrDefaultAsync(order=>order.User.UserId==id);
        }
    }
}
