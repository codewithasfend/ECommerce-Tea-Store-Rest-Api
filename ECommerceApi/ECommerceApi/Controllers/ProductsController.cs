using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApiDbContext dbContext;
        public ProductsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // GET /api/Products?productType = category & categoryId = 5
        // GET /api/Products?productType = trending
        // GET /api/Products?productType = bestselling

        [HttpGet]
        public IActionResult GetProducts(string productType, int? categoryId = null)
        {
            var products = dbContext.Products.AsQueryable();

            if (productType == "category" && categoryId != null)
            {
                products = products.Where(v => v.CategoryId == categoryId);
            }
            else if (productType == "trending")
            {
                products = products.Where(v => v.IsTrending == true);
            }
            else if (productType == "bestselling")
            {
                products = products.Where(v => v.IsBestSelling == true);
            }
            else
            {
                return BadRequest("Invalid product type");
            }

            var productData = products.Select(v => new
            {
                Id = v.Id,
                Name = v.Name,
                Price = v.Price,
                ImageUrl = v.ImageUrl
            });

            return Ok(productData);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductDetail(int id)
        {
            var product = dbContext.Products.Where(p => p.Id == id);
            var productData = product.Select(v => new
            {
                Id = v.Id,
                Name = v.Name,
                Price = v.Price,
                Detail = v.Detail,
                ImageUrl = v.ImageUrl
            }).FirstOrDefault();
            return Ok(productData);
        }
    }
}
