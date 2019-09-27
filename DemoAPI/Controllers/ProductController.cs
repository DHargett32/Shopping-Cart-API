using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class ProductController : ApiController
    {
        // a list of products that will be used for testing purposes
        List<Product> products = new List<Product>();

        /// <summary>
        /// constructor
        /// </summary>
        public ProductController()
        {
            // add sample data to the <Product> list
            products.Add(new Product { ProductID = 1, Description = "Red Stapler", Price = 50.00, Quantity = 10});
            products.Add(new Product { ProductID = 2, Description = "TPS Report", Price = 3.00, Quantity = 50});
            products.Add(new Product { ProductID = 3, Description = "Printer", Price = 399.99, Quantity = 8});
            products.Add(new Product { ProductID = 4, Description = "Baseball bat", Price = 80.00, Quantity = 12});
            products.Add(new Product { ProductID = 5, Description = "Michael Bolton CD", Price = 12.00, Quantity = 20});
            products.Add(new Product { ProductID = 3, Description = "The Holy Grail", Price = 1000.00, Quantity = 0 });
        }

        // GET: api/Product
        /// <summary>
        /// Returns an IEnumerable List of Products that are available (Quantity > 0)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Get()
        {
            return products.Where(q => q.Quantity > 0);
        }

        // GET: api/Product/5
        /// <summary>
        /// Returns a Product based on an ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*public Product Get(int id)
        {
            return products.Where(q => q.ProductID == id).Single();
        }*/

        // POST: api/Product
        
        public void Post(List<Product> prods)
        {
            foreach (Product product in prods)
                products.Add(product);
        }

        // PUT: api/Product/5
        /*public void Put(int id, [FromBody]string value)
        {

        }*/

        // DELETE: api/Product/5
        /*public void Delete(int id)
        {

        }*/
    }
}
