using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public kitapContainer kitap = new kitapContainer();

        public BaseController()
        {
            var httpContext = System.Web.HttpContext.Current;

            if (httpContext.Application["kategoriler"] == null)
            {
                httpContext.Application["kategoriler"] = kitap.KategoriSet.ToList();
            }
        }      
    }
}