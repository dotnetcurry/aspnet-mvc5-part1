using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Michaels_Stuff.Utils;
namespace Michaels_Stuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Send mail to yourself
            //Discuss in Class
            try
            {
                //EmailUtility.SendHotmail();
            }
            catch
            {

            }
          
  

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "MVC 5 Road to Job Secuity";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kendallsoft Academy";

            return View();
        }
    }
}