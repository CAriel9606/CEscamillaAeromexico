using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class VueloController : Controller
    {
        // GET: Vuelo
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Vuelo vuelo = new ML.Vuelo();
            vuelo.Vuelos = new List<object>();

            using( var client = new HttpClient())
            {
                string UriApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(UriApi);

                var responseTask = client.GetAsync("api/vuelo/getall");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach(var resultItem in readTask.Result.Objects)
                    {
                        ML.Vuelo resultItmeList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Vuelo>(resultItem.ToString());
                        vuelo.Vuelos.Add(resultItmeList);
                    }
                }
            }

            return View(vuelo);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Vuelo vuelo)
        {
            vuelo.Vuelos = new List<object>();
            //vuelo.FechaInicio = DateTime.Parse(vuelo.FechaInicio.ToString("MM-dd-yyyy"));

            using (var client = new HttpClient())
            {
                string UriApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(UriApi);

                var responseTask = client.GetAsync("api/vuelo/getbyfecha/" + vuelo.FechaInicio.ToString("MM-dd-yyyy") +"/"+ vuelo.FechaFin.ToString("MM-dd-yyyy"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Vuelo resultItmeList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Vuelo>(resultItem.ToString());
                        vuelo.Vuelos.Add(resultItmeList);
                    }
                }
            }

            return View(vuelo);
        }


    }
}