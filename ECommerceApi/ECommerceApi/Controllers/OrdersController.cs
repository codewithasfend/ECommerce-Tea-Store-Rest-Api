using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECommerceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ApiDbContext dbContext;
        public OrdersController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Orders/OrderDetails/5
        [HttpGet("[action]/{orderId}")]
        public IActionResult OrderDetails(int orderId)
        {
            var orderDetails = from orderDetail in dbContext.OrderDetails
                               join order in dbContext.Orders on orderDetail.OrderId equals order.Id
                               join product in dbContext.Products on orderDetail.ProductId equals product.Id
                               where orderDetail.OrderId == orderId

                               select new
                               {
                                   Id = orderDetail.Id,
                                   Qty = orderDetail.Qty,
                                   SubTotal = orderDetail.TotalAmount,
                                   ProductName = product.Name,
                                   ProductImage = product.ImageUrl,
                                   ProductPrice = product.Price,
                               };

            return Ok(orderDetails);
        }


        // GET: api/Orders/OrdersByUser/5
        [HttpGet("[action]/{userId}")]
        public IActionResult OrdersByUser(int userId)
        {
            var orders = from order in dbContext.Orders
                         where order.UserId == userId
                         orderby order.OrderPlaced descending
                         select new
                         {
                             Id = order.Id,
                             OrderTotal = order.OrderTotal,
                             OrderPlaced = order.OrderPlaced,
                         };

            return Ok(orders);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            order.OrderPlaced = DateTime.Now;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            var shoppingCartItems = dbContext.ShoppingCartItems.Where(cart => cart.CustomerId == order.UserId);
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Price = item.Price,
                    TotalAmount = item.TotalAmount,
                    Qty = item.Qty,
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                };
                dbContext.OrderDetails.Add(orderDetail);
            }

            dbContext.SaveChanges();
            dbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);
            dbContext.SaveChanges();

            return Ok(new { OrderId = order.Id });
        }
    }
}
