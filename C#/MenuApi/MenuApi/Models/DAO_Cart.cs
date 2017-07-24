using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantDB;

namespace MenuApi.Models
{
    public static class DAO_Cart
    {
        public static Cart theCart = null;
       public static void UpdateCartDB(string action, string itemName)
        {
            RestaurantAppDBEntities DB = new RestaurantAppDBEntities();
            switch (action)
            {
                case "ADD":
                    {
                        int menuPK = 0;
                        var menu = from m in DB.Menus
                                   where m.ItemName == itemName
                                   select m;
                        menuPK = menu.ToList()[0].pk;
                        RestaurantDB.Cart tmp = new RestaurantDB.Cart();
                        tmp.fk_user = theCart.pk;
                        tmp.fk_item = menuPK;
                        DB.Carts.Add(tmp);
                        DB.SaveChanges();
                    }
                    break;
                case "DEL":
                    {
                        int menuPK = 0;
                        var menu = from m in DB.Menus
                                   where m.ItemName == itemName
                                   select m;
                        menuPK = menu.ToList()[0].pk;
                        int amount = 0;
                        var cart = from c in DB.Carts
                                   where c.fk_user == theCart.pk
                                   select c;

                        RestaurantDB.Cart tmp = new RestaurantDB.Cart();
                        foreach (var i in cart)
                        {
                            if (i.fk_item == menuPK)
                            {
                                amount++;
                                tmp = i;
                            }
                        }                        
                        DB.Carts.Remove(tmp);
                        //for (int i = 0; i < amount - 1; i++)
                        //{
                        //    DB.Carts.Add(tmp);
                        //}
                        DB.SaveChanges();
                    }
                    break;
                default:
                    break;
            }
        }
        public static void LoadCart(string userName, string Password)
        {            
            RestaurantAppDBEntities DB = new RestaurantAppDBEntities();
            var user = from u in DB.Users
                       where u.UserName == userName && u.UserPassword == Password
                       select u;

            if(user.ToList().Count == 0)
            {
                User userTmp = new User();
                userTmp.UserName = userName;
                userTmp.UserPassword = Password;
                userTmp.UserAddress = "Unknown";
                DB.Users.Add(userTmp);
                DB.SaveChanges();

                user = from u in DB.Users
                       where u.UserName == userName && u.UserPassword == Password
                       select u;
            }
            
                theCart.name = user.ToList()[0].UserName;
                theCart.address = user.ToList()[0].UserAddress;
                theCart.password = user.ToList()[0].UserPassword;
                theCart.pk = user.ToList()[0].pk;
                theCart.items.Clear();

            var cart = from c in DB.Carts
                       where c.fk_user == theCart.pk
                       select c;
            foreach (var i in cart)
            {                
                var menu = from m in DB.Menus
                           where m.pk == i.fk_item
                           select m;

                if(menu.ToList()[0].ItemName != null)
                AddToCart(menu.ToList()[0].ItemName, 1, menu.ToList()[0].Price);
            }
        }

        public static void AddToCart(string name, int amount, double price)
        {
            CartItem tmp = new CartItem();
            tmp.name = name;
            tmp.amount = amount;
            tmp.price = price;

            if (theCart.items.Count == 0)
            {
                theCart.items.Add(tmp);
            }
            else
            {
                for (int i = 0; i < theCart.items.Count; i++)
                {
                    if (theCart.items[i].name == tmp.name)
                    {
                        theCart.items[i].amount++;
                        theCart.items[i].price += tmp.price;
                        return;
                    }
                }
               theCart.items.Add(tmp);
            }

        }
        public static void RemoveToCart(string name, double price)
        {
            for (int i = 0; i < theCart.items.Count; i++)
            {
                if (theCart.items[i].name == name)
                {
                    if (theCart.items[i].amount < 2)
                    {
                        theCart.items.Remove(theCart.items[i]);
                        return;
                    }
                    else
                    {
                        var subtract = theCart.items[i].price / theCart.items[i].amount;
                        theCart.items[i].amount--;
                        theCart.items[i].price -= subtract;
                        return;
                    }
                }
            }
        }
    }
}