using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantDB;

namespace MenuApi.Models
{
    public static class DAO_Menu
    {
        public static List<MenuCategory> theMenu = new List<MenuCategory>();
        
        public static void FillDefaultMenu()
        {
            theMenu = new List<MenuCategory>();
            RestaurantAppDBEntities database = new RestaurantAppDBEntities();

            foreach (var c in database.Categories)
            {
                MenuCategory tmp = new MenuCategory();
                tmp.name = c.category1;
                var list = from m in database.Menus where m.fk_Category == c.pk select m;
                foreach(var i in list)
                {
                    MenuItem tmp2 = new MenuItem();
                    tmp2.name = i.ItemName;
                    tmp2.price = i.Price;
                    tmp.list.Add(tmp2);
                }
                theMenu.Add(tmp);
            }            
        }
    }
}