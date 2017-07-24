using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shapes;

namespace demo.webapi.Controllers
{
    public class ShapeController : ApiController
    {
        theShapes[] shapes = new theShapes[]
        {
            new theShapes(1,2), new theShapes(4,3), new Rectangle(7,8)
        };
        /// <summary>
        /// default GET
        /// route : api/shape
        /// </summary>
        /// <returns></returns>
        public IEnumerable<theShapes> GetShape()
        {
            return shapes;
        }
    }
}
