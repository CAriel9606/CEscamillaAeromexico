using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario)
        {
            var contrasenia = usuario.Contrasenia;
            string UrlAPI = ConfigurationManager.AppSettings["WebAPI"].ToString();
            
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UrlAPI);
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("api/Login", usuario);
                    postTask.Wait();
                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        var readTask = resultPost.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItmeList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        usuario=resultItmeList;
                        if(contrasenia==usuario.Contrasenia)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Mensaje = "Credenciales incorrectas vuelva a intentarlo";
                            return PartialView("ModalPV");
                        }
                        
                    }
                    else
                    {
                        ViewBag.Mensaje = "Usuario no admitido : " + resultPost.StatusCode;
                        return PartialView("ModalPV");
                    }
                }
            }
            return View(usuario);
        }
    }
}