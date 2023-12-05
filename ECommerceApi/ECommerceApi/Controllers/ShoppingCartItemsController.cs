using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemsController : ControllerBase
    {
        private ApiDbContext dbContext;
        public ShoppingCartItemsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/ShoppingCartItems/1
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var user = dbContext.ShoppingCartItems.Where(s => s.CustomerId == userId);
            if (user == null)
            {
                return NotFound();
            }

            var shoppingCartItems = from s in dbContext.ShoppingCartItems.Where(s => s.CustomerId == userId)
                                    join p in dbContext.Products on s.ProductId equals p.Id

                                    select new
                                    {
                                        Id = s.Id,
                                        Price = s.Price,
                                        TotalAmount = s.TotalAmount,
                                        Qty = s.Qty,
                                        ProductId = p.Id,
                                        ProductName = p.Name,
                                        ImageUrl = p.ImageUrl

                                    };

            return Ok(shoppingCartItems);
        }

        // POST: api/ShoppingCartItems
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCartItem shoppingCartItem)
        {
            var shoppingCart = dbContext.ShoppingCartItems.FirstOrDefault(s => s.ProductId == shoppingCartItem.ProductId && s.CustomerId == shoppingCartItem.CustomerId);
            if (shoppingCart != null)
            {
                shoppingCart.Qty += shoppingCartItem.Qty;
                shoppingCart.TotalAmount = shoppingCart.Price * shoppingCart.Qty;
            }
            else
            {
                // Getting Product Price
                var productRecord = dbContext.Products.Find(shoppingCartItem.ProductId);


                var sCart = new ShoppingCartItem()
                {
                    CustomerId = shoppingCartItem.CustomerId,
                    ProductId = shoppingCartItem.ProductId,
                    Price = shoppingCartItem.Price,
                    Qty = shoppingCartItem.Qty,
                    TotalAmount = (productRecord.Price) * (shoppingCartItem.Qty)
                };
                dbContext.ShoppingCartItems.Add(sCart);
            }
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT /api/ShoppingCartItems?productId = 1 & action = "increase"
        // PUT /api/ShoppingCartItems?productId = 1 & action = "decrease"
        // PUT /api/ShoppingCartItems?productId = 1 & action = "delete"

       // [HttpPut("{productId}/{action}")]
        [HttpPut]
        public IActionResult Put(int productId, string action)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = dbContext.Users.FirstOrDefault(u => u.Email == userEmail);

            var shoppingCart = dbContext.ShoppingCartItems.FirstOrDefault(s => s.CustomerId == user.Id && s.ProductId == productId);

            if (shoppingCart != null)
            {
                if (action.ToLower() == "increase")
                {
                    shoppingCart.Qty += 1;
                }
                else if (action.ToLower() == "decrease")
                {
                    if (shoppingCart.Qty > 1)
                    {
                        shoppingCart.Qty -= 1;
                    }
                    else
                    {
                        dbContext.ShoppingCartItems.Remove(shoppingCart);
                        dbContext.SaveChanges();
                        return Ok();
                    }
                }
                else if (action.ToLower() == "delete")
                {
                    // Remove the item from the cart.
                    dbContext.ShoppingCartItems.Remove(shoppingCart);
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    // Return a response indicating an invalid action.
                    return BadRequest("Invalid action. Use 'increase', 'decrease', or 'delete'.");
                }

                shoppingCart.TotalAmount = shoppingCart.Price * shoppingCart.Qty;
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                // Return a response indicating that the item was not found in the cart.
                return NotFound();
            }
        }

    }
}
