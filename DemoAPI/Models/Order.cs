using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Order
    {
        // the unique order number
        public int OrderNum { get; set; }
        // the products that comprise the order
        public Cart Products { get; set; }

        // constructor
        public Order(int orderNum, Cart products)
        {
            OrderNum = orderNum;
            Products = products;
        }

    }
}