using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuApi.Models;
using System.Web.Http.Cors;
namespace MenuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CartController : ApiController
    {        
        public Cart GetCart()
        {
            if (DAO_Cart.theCart == null)
                DAO_Cart.theCart = new Cart();

            DAO_Cart.LoadCart(DAO_Cart.theCart.name, DAO_Cart.theCart.password);
            return DAO_Cart.theCart;
        }
        public void AddItem(string name, int amount, double price)
        {
            DAO_Cart.AddToCart(name, amount, price);
            DAO_Cart.UpdateCartDB("ADD", name);

        }
        public void RemoveItem(string name, double price)
        {
            DAO_Cart.RemoveToCart(name, price);
            DAO_Cart.UpdateCartDB("DEL", name);
        }
        public void UpdateCart()
        {

        }
        public double GetTotal()
        {
            double result = 0;
            for (int i = 0; i < DAO_Cart.theCart.items.Count; i++)
            {
                result += DAO_Cart.theCart.items[i].price;
            }
            return result;
        }
    }
}
