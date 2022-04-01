using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: Pasajero

        [HttpGet]
        public ActionResult Form()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);
            
            if(result.Correct)
            {
                ViewBag.Mensaje = "El pasajero se ingreso correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un eror al ingresar al Pasajero";
            }
            return PartialView("ModalPV");
        }
    }
}