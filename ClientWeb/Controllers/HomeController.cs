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

        public ActionResult Create()
        {
            
            List<SelectListItem> _items = new List<SelectListItem>();
            _items.Add(new SelectListItem { Text = "Seleccionar", Value = "" });
            _items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            _items.Add(new SelectListItem { Text = "NO", Value = "NO" });

            ViewBag._dataState = _items;

            return View();
        }

        // POST: Tarea/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                    Entidades.Entidades.TareaForm _dataClient = new Entidades.Entidades.TareaForm();
                    _dataClient.id_tarea = Convert.ToInt64(collection["id_tarea"]);
                    _dataClient.id_status_ini = Convert.ToInt64(collection["id_status_ini"]);
                    _dataClient.nombre_tomador = Convert.ToString(collection["nombre_tomador"]);
                    _dataClient.dni_tomador = Convert.ToString(collection["dni_tomador"]);
                    _dataClient.telefono_tomador = Convert.ToInt64(collection["telefono_tomador"]);

                    List<Entidades.Entidades.AseguradoForm> _listAsegurados = new List<Entidades.Entidades.AseguradoForm>();
                    var _keys = collection.AllKeys.Where(_element => (_element.Contains("dniDATA_") || _element.Contains("nombreDATA_") || _element.Contains("telefonoDATA_") || _element.Contains("llamarDATA_") || _element.Contains("fechaDATA_"))).ToArray();
                    var _keysInt = _keys.Select(_element => Convert.ToInt32(_element.Split('_')[1])).Distinct().ToArray();

                    if (_keysInt.Count() == 0)
                    {
                        // Mirar como mostrar error en el campo
                        return View();
                    }

                    foreach (var item in _keysInt)
                    {
                        Entidades.Entidades.AseguradoForm _data = new Entidades.Entidades.AseguradoForm();
                        _data.id_asegurado = 0;
                        _data.nombre = Convert.ToString(collection["nombreDATA_" + item]);
                        _data.dni = Convert.ToString(collection["dniDATA_" + item]);
                        _data.telefono = Convert.ToInt64(collection["telefonoDATA_" + item]);
                        _data.llamar_asegurado = Convert.ToString(collection["llamarDATA_" + item]);
                        _data.fecha_hora = Convert.ToString(collection["fechaDATA_" + item]);
                        //_data.fecha_hora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        _listAsegurados.Add(_data);
                    }
                    _dataClient.asegurados = _listAsegurados;
                    //Entidades.WebService.AegonCarga _dataAegonWS = new Entidades.WebService.AegonCarga(_dataClient);
                    //AccesoDatos.WebServiceAegon _bridgeAegonWS = new AccesoDatos.WebServiceAegon();
                    //var _responseWS = _bridgeAegonWS.saveData(_dataAegonWS);

                    // Mostrar mensaje en la pantalla de inicio

                    //db.programa.Add(programa);
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }

                //return View(programa);
                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}