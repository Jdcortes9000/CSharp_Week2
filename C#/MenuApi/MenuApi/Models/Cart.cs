using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuApi.Models
{
    public class Cart
    {
        public string name = "User";
        public string address = "Unknow";
        public string password = "password";
        public int pk = 0;
        public List<CartItem> items = new List<CartItem>();       
    }
}