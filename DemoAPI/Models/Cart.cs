using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
            GrandTotal = 0;
        }

        // the products in the cart
        public List<Product> Products { get; set; }
        // the grand total of all the items within the cart
        public double GrandTotal { get; set; }

        /// <summary>
        /// adds a one or more products to the cart and recalculates the grand total of the products in the cart
        /// </summary>
        /// <param name="products"></param>
        public void UpdateCart(List<Product> products)
        {
            double grandTotal = 0;

            foreach (Product prod in products)
            {
                // If product ID exists in our cart already, update the quantity with the new value
                // if the product ID does not exist, add the whole object to the Products<> list
                if (Products.Select(q => q.ProductID).Contains(prod.ProductID))
                {
                    // ideally we would check the quantity that is available for a given product and ensure that the updated value does not exceed that amount
                    // assuming that this check has already happened, we can update the quantity in our cart with the new amount
                    int originalQuantity = Products.Where(q => q.ProductID == prod.ProductID).Single().Quantity;
                    Products.Where(q => q.ProductID == prod.ProductID).Single().Quantity = prod.Quantity;
                    grandTotal += ((prod.Price * prod.Quantity) - (prod.Price * originalQuantity));
                }
                else
                {
                    Products.Add(prod);
                    grandTotal += (prod.Price * prod.Quantity);
                }

                
            }

            GrandTotal += grandTotal;
        }
    }
}