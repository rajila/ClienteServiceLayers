using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name, string currentFilter, int? page)
        {
            WSTest.WSBridge _ws = new WSTest.WSBridge();
            ViewBag.msnWS = _ws.getMessage("ss");
            TempData["msnWS"] = _ws.getMessage("ss");

            // Valores definidos en la acción Save
            ViewBag._statusSave = TempData["_statusSave"];
            if (ViewBag._statusSave != null && ViewBag._statusSave)
            {
                var _task = (Entidades.Entidades.TareaForm)TempData["_taskSave"];
                ViewBag._messageSave = "El registro se guardo exitosamente: "+" ID Tarea "+_task.id_tarea;
            }

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
            Entidades.Entidades.TareaForm _dataClient = new Entidades.Entidades.TareaForm();
            ViewBag._statusSave = true;
            ViewBag._messageSave = "OK";

            // Set los valores en el Modelo
            TryUpdateModel(_dataClient);

            var _statusAsegurado = true;
            Entidades.Entidades.AseguradoForm _rowAsegurado = null;
            var _countRowA = 0;
            List<ValidationResult> _validationResultsTmp = null;

            try
            {
                if (ModelState.IsValid)
                {
                    //_dataClient.id_tarea = Convert.ToInt64(collection["id_tarea"]);
                    //_dataClient.id_status_ini = Convert.ToInt64(collection["id_status_ini"]);
                    //_dataClient.nombre_tomador = Convert.ToString(collection["nombre_tomador"]);
                    //_dataClient.dni_tomador = Convert.ToString(collection["dni_tomador"]);
                    //_dataClient.telefono_tomador = Convert.ToInt64(collection["telefono_tomador"]);

                    var validationResults = new List<ValidationResult>();
                    ValidationContext contexts = new ValidationContext(_dataClient, null, null);
                    var isValid = Validator.TryValidateObject(_dataClient, contexts, validationResults, true);

                    List<Entidades.Entidades.AseguradoForm> _listAsegurados = new List<Entidades.Entidades.AseguradoForm>();
                    var _keys = collection.AllKeys.Where(_element => (_element.Contains("dniDATA_") || _element.Contains("nombreDATA_") || _element.Contains("telefonoDATA_") || _element.Contains("llamarDATA_") || _element.Contains("fechaDATA_"))).ToArray();
                    var _keysInt = _keys.Select(_element => Convert.ToInt32(_element.Split('_')[1])).Distinct().ToArray();

                    if (_keysInt.Count() == 0)
                    {
                        // Mirar como mostrar error en el campo
                        ViewBag._statusSave = false;
                        ViewBag._messageSave = "Error, debe ingresar al menos un Asegurado";
                        return View(_dataClient);
                    }

                    foreach (var item in _keysInt)
                    {
                        Entidades.Entidades.AseguradoForm _data = new Entidades.Entidades.AseguradoForm();
                        _data.id_asegurado = 0;
                        _data.nombre = Convert.ToString(collection["nombreDATA_" + item]);
                        _data.dni = Convert.ToString(collection["dniDATA_" + item]);
                        if (!String.IsNullOrEmpty(collection["telefonoDATA_" + item])) _data.telefono = Convert.ToInt64(collection["telefonoDATA_" + item]);
                        //else _data.telefono = -1;
                        _data.llamar_asegurado = Convert.ToString(collection["llamarDATA_" + item]);
                        _data.fecha_hora = Convert.ToString(collection["fechaDATA_" + item]);
                        //_data.fecha_hora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        _listAsegurados.Add(_data);
                    }
                    _dataClient.asegurados = _listAsegurados;

                    // Guardamos el listado de asegurados en JSON para pasar a la vista
                    ViewBag._aseguradoJSON = JsonConvert.SerializeObject(_listAsegurados);

                    // Validar los campos del asegurado
                    foreach (var _element in _dataClient.asegurados)
                    {
                        _countRowA++;
                        var _validationResults = new List<ValidationResult>();
                        ValidationContext _contexts = new ValidationContext(_element, null, null);
                        var _isValid = Validator.TryValidateObject(_element, _contexts, _validationResults, true);
                        if (!_isValid)
                        {
                            _statusAsegurado = false;
                            _rowAsegurado = _element;
                            _validationResultsTmp = _validationResults;
                            break;
                        }
                    }

                    // Existe un asegurado que no cumple con las validaciones
                    if (!_statusAsegurado)
                    {
                        //var messages = _validationResultsTmp.Select(r => r.ErrorMessage).ToList().Aggregate((message, nextMessage) => message + "\n" + nextMessage);
                        var _messages = _validationResultsTmp.Select(_el => _el.ErrorMessage).ToList();
                        ViewBag._statusSave = false;
                        ViewBag._messageSave =  "Error Asegurado # " + _countRowA + " :";
                        ViewBag._messageSaveBody = _messages;

                        return View(_dataClient);
                    }

                    //////Entidades.WebService.AegonCarga _dataAegonWS = new Entidades.WebService.AegonCarga(_dataClient);
                    //////AccesoDatos.WebServiceAegon _bridgeAegonWS = new AccesoDatos.WebServiceAegon();
                    //////var _responseWS = _bridgeAegonWS.saveData(_dataAegonWS);

                    // Mostrar mensaje en la pantalla de inicio
                    TempData["_statusSave"] = true;
                    TempData["_taskSave"] = _dataClient;

                    return RedirectToAction("Index");
                } else {
                    ViewBag._statusSave = false;
                    ViewBag._messageSave = "Hay campos vacíos";
                }
            }catch {
                ViewBag._statusSave = false;
                ViewBag._messageSave = "Error, por favor intentarlo mas tarde";
            }

            return View(_dataClient);
        }

        // GET: Tarea/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Entidades.Entidades.TareaForm _tarea = new Entidades.Entidades.TareaForm();
            _tarea.id_tarea = 1;
            _tarea.status_ini = "INI";
            _tarea.id_status_ini = 1;
            _tarea.status_now = "INI";
            _tarea.id_status_fin = 1;
            _tarea.nombre_tomador = "Ronald";
            _tarea.dni_tomador = "1104537574";
            _tarea.telefono_tomador = 12345678;
            _tarea.id_tomador = 1;
            _tarea.fecha = "11/06/2019 16:50";

            List<Entidades.Entidades.AseguradoForm> _listAsegurado = new List<Entidades.Entidades.AseguradoForm> ();
            Entidades.Entidades.AseguradoForm _dataOne = new Entidades.Entidades.AseguradoForm();
            _dataOne.id_asegurado = 1;
            _dataOne.nombre = "Thalia";
            _dataOne.dni = "12345";
            _dataOne.telefono = 32424325;
            _dataOne.llamar_asegurado = "SI";
            _dataOne.fecha_hora = "20/06/2019 16:50";
            _listAsegurado.Add(_dataOne);

            Entidades.Entidades.AseguradoForm _dataTwo = new Entidades.Entidades.AseguradoForm();
            _dataTwo.id_asegurado = 1;
            _dataTwo.nombre = "Mary";
            _dataTwo.dni = "454654";
            _dataTwo.telefono = 56546646;
            _dataTwo.llamar_asegurado = "SI";
            _dataTwo.fecha_hora = "21/06/2019 16:50";
            _listAsegurado.Add(_dataTwo);

            _tarea.asegurados = _listAsegurado;

            List<SelectListItem> _items = new List<SelectListItem>();
            _items.Add(new SelectListItem { Text = "Seleccionar", Value = "" });
            _items.Add(new SelectListItem { Text = "SI", Value = "1" });
            _items.Add(new SelectListItem { Text = "NO", Value = "0" });

            ViewBag._dataState = _items;


            if (_tarea == null) return HttpNotFound();

            return View(_tarea);
        }

        [HttpPost]
        public JsonResult AjaxPostCallHistory(Entidades.Entidades.HistoricoTareaJSON historico)
        {
            List<Entidades.Entidades.AseguradoForm> _listAsegurado = new List<Entidades.Entidades.AseguradoForm>();
            Entidades.Entidades.AseguradoForm _dataOne = new Entidades.Entidades.AseguradoForm();
            _dataOne.id_asegurado = 1;
            _dataOne.nombre = "Thalia";
            _dataOne.dni = "12345";
            _dataOne.telefono = 32424325;
            _dataOne.llamar_asegurado = "SI";
            _dataOne.fecha_hora = "20/06/2019 16:50";
            _listAsegurado.Add(_dataOne);

            Entidades.Entidades.AseguradoForm _dataTwo = new Entidades.Entidades.AseguradoForm();
            _dataTwo.id_asegurado = 1;
            _dataTwo.nombre = "Mary";
            _dataTwo.dni = "454654";
            _dataTwo.telefono = 56546646;
            _dataTwo.llamar_asegurado = "SI";
            _dataTwo.fecha_hora = "21/06/2019 16:50";
            _listAsegurado.Add(_dataTwo);

            return Json(_listAsegurado, JsonRequestBehavior.AllowGet);
        }
    }
}