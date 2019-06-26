using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTotNghiep.Models;

namespace WebTotNghiep.Controllers
{
    public class HomeController : Controller
    {
        ModelClient db = new ModelClient();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Banner()
        {
            

            return PartialView();
        }
       
    }
}