using Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Reposetories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyShop
{
    public class OrderTest
    {
        // ... existing code ...

        [Fact]
        public async Task CheckOrderSum_ValidCredentialsReturnOrder()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Price = 40 },
                new Product { Id = 2, Price = 20 }
            };

            var orders = new List<Order>
            {
                new Order
                {
                    UserId = 1,
                    OrderSum = 100,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { ProductId = 1, Quantity = 2 },
                        new OrderItem { ProductId = 2, Quantity = 1 }
                    }
                }
            };

            var mockContext = new Mock<_214416448WebApiContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            var productRepository = new Mock<IProductReposetory>();
            productRepository.Setup(x => x.getProductById(1)).ReturnsAsync(products[0]);
            productRepository.Setup(x => x.getProductById(2)).ReturnsAsync(products[1]);

            var orderRepository = new Mock<IOrderReposetory>();
            orderRepository.Setup(x => x.getOrderById(1)).ReturnsAsync(orders[0]);
            orderRepository.Setup(x => x.getOrderById(2)).ReturnsAsync(orders[1]);

            var mockLogger = new Mock<ILogger<OrderServices>>();
            var orderService = new OrderServices(orderRepository.Object, productRepository.Object, mockLogger.Object);

            var result = await orderService.addOrder(orders[0]);
            Assert.Equal(result, orders[0]);
        }

        [Fact]
        public async Task CheckOrderSum_InvalidOrderSumUpdatesOrderSum()
        {
            var products = new List<Product>
                {
                    new Product { Id = 1, Price = 40 },
                    new Product { Id = 2, Price = 20 }
                };

            var invalidOrder = new Order
            {
                UserId = 1,
                OrderSum = 50,
                OrderItems = new List<OrderItem>
                    {
                        new OrderItem { ProductId = 1, Quantity = 2 },
                        new OrderItem { ProductId = 2, Quantity = 1 }
                    }
            };

            var mockContext = new Mock<_214416448WebApiContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(new List<Order>());
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            var productRepository = new Mock<IProductReposetory>();
            productRepository.Setup(x => x.getProductById(1)).ReturnsAsync(products[0]);
            productRepository.Setup(x => x.getProductById(2)).ReturnsAsync(products[1]);

            var orderRepository = new OrderReposetory(mockContext.Object);
            var mockLogger = new Mock<ILogger<OrderServices>>();
            var orderService = new OrderServices(orderRepository, productRepository.Object, mockLogger.Object);

            var result = await orderService.addOrder(invalidOrder);

            Assert.NotNull(result);
            Assert.Equal(100, result.OrderSum);
            Assert.Equal(invalidOrder.UserId, result.UserId);
            Assert.Equal(invalidOrder.OrderItems.Count, result.OrderItems.Count);
        }
    }
}
