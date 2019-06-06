using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AccesoDatos.WebServiceL _serviceBridge = new AccesoDatos.WebServiceL();
            var _data = _serviceBridge.getMessage("Ronald Daniel");
            var _suma = _serviceBridge.suma(4,5);

            //AccesoDatos.WebServiceW _serviceBridge = new AccesoDatos.WebServiceW();
            //var _data = _serviceBridge.getMessage("Ronald Daniel");
            ViewBag._data = _data;
            ViewBag._suma = _suma;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}