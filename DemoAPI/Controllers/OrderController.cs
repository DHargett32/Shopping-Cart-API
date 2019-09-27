using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class OrderController : ApiController
    {
        // will hold all the orders 
        List<Order> orders = new List<Order>();
        // will be used to help create each order
        Cart cart;
        // sample product lists that represent the products in different orders
        List<Product> productsOrderList1 = new List<Product>();
        List<Product> productsOrderList2 = new List<Product>();

        /// <summary>
        /// constructor
        /// </summary>
        OrderController()
        {

            // add products to both product lists
            //
            // product list #1
            productsOrderList1.Add(new Product { ProductID = 1, Description = "Red Stapler", Price = 50.00, Quantity = 2 });
            productsOrderList1.Add(new Product { ProductID = 2, Description = "TPS Report", Price = 3.00, Quantity = 3 });

            // product list #2
            productsOrderList2.Add(new Product { ProductID = 1, Description = "Red Stapler", Price = 50.00, Quantity = 1 });
            productsOrderList2.Add(new Product { ProductID = 2, Description = "TPS Report", Price = 3.00, Quantity = 1 });
            productsOrderList2.Add(new Product { ProductID = 3, Description = "Printer", Price = 399.99, Quantity = 2 });
            productsOrderList2.Add(new Product { ProductID = 4, Description = "Baseball bat", Price = 80.00, Quantity = 1 });
            productsOrderList2.Add(new Product { ProductID = 5, Description = "Michael Bolton CD", Price = 12.00, Quantity = 1 });


            // create order #1
            cart = new Cart();
            cart.UpdateCart(productsOrderList1);
            orders.Add(new Order(1, cart));

            // create order #2
            cart = new Cart();
            cart.UpdateCart(productsOrderList2);
            orders.Add(new Order(2, cart));

        }

        // GET: api/Order
        /// <summary>
        /// get all the orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> Get()
        {
            return orders;
        }

        // GET: api/Order/5
        /// <summary>
        /// get an order based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Get(int id)
        {
            return orders.Where(q => q.OrderNum == id).Single();
        }

        // POST: api/Order
        /// <summary>
        /// post "checkout"(create) an order
        /// </summary>
        /// <param name="order"></param>
        public void Post(Order order)
        {
            orders.Add(order);
        }

        // PUT: api/Order/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE: api/Order/5
        /*public void Delete(int id)
        {
        }*/
    }
}
