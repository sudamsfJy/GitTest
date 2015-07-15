using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public IEnumerable<Product> DeleteProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if(product ==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);       
            }
            else
            {
                products = products.Where(x => x.Id != product.Id).ToArray();
                var response = new HttpResponseMessage();
                response.Headers.Add("Message","Success Delete");
                return products;
            }
        }
    }
}
