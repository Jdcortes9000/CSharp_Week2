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
    public class MenuController : ApiController
    {
              
        public IEnumerable<MenuCategory> GetMenu()
        {
            DAO_Menu.FillDefaultMenu();
            return DAO_Menu.theMenu;
        }
    }
}
