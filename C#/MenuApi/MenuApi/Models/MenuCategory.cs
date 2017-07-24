using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuApi.Models
{
    public class MenuCategory
    {
        public string name;
        public List<MenuItem> list = new List<MenuItem>();
    }
}