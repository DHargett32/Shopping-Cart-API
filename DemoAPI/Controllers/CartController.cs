using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class CartController : ApiController
    {
        // a list of products that will be stored in our cart
        public List<Product> products = new List<Product>();
        // a cart object that will be used for testing purposes
        public Cart cart = new Cart();

        /// <summary>
        /// constructor
        /// </summary>
        public CartController()
        {
            // populate a Cart object with sample data for testing purposes
            // add a few products and the grand total of the order
            products.Add(new Product { ProductID = 1, Description = "Red Stapler", Price = 50.00, Quantity = 2 });
            products.Add(new Product { ProductID = 2, Description = "TPS Report", Price = 3.00, Quantity = 3 });
            cart.UpdateCart(products);
        }

        // GET: api/Cart
        /// <summary>
        /// get all products in the cart
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Get()
        {
            return cart.Products;
        }

        // GET: api/Cart/5
        /*public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Cart
        /// <summary>
        /// will update the product list within the cart
        /// </summary>
        /// <param name="prods"></param>
        public void Post(List<Product> prods)
        {
            cart.UpdateCart(prods);
        }

        // PUT: api/Cart/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE: api/Cart/5
        /// <summary>
        /// will remove all occurences of a product from the cart based on the ID passed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Product> Delete(int id)
        {
            cart.Products.Remove(cart.Products.Where(q => q.ProductID == id).Single());

            return cart.Products;
        }
    }
}
