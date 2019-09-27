using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Product
    {
        // the id of the product
        public int ProductID { get; set; }
        // the product description
        public string Description { get; set; }
        // the price of the product
        public double Price { get; set; }
        // the quantity of a product that is available
        public int Quantity { get; set; }
    }
}