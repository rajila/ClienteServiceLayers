using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;

namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name, string currentFilter, int? page)
        {
            //AccesoDatos.WebServiceL _serviceBridge = new AccesoDatos.WebServiceL();
            //var _data = _serviceBridge.getMessage("Ronald Daniel");
            //var _suma = _serviceBridge.suma(4,5);

            //AccesoDatos.WebServiceW _serviceBridge = new AccesoDatos.WebServiceW();
            //var _data = _serviceBridge.getMessage("Ronald Daniel");
            //ViewBag._data = _data;
            //ViewBag._suma = _suma;

            if (name != null) page = 1;
            else name = currentFilter;

            ViewBag.CurrentFilter = name;

            AccesoDatos.UserBridge _userB = new AccesoDatos.UserBridge();
            var _elements = _userB.getAllElements();

            if (!String.IsNullOrEmpty(name))
                _elements = _elements.Where(element => element.name.Contains(name)).ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("Test", _elements.ToPagedList(pageNumber, pageSize) );
            //return View("Test", _elements);
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