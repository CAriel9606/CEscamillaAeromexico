using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pasajero.Controllers
{
    public class VueloController : ApiController
    {

        [HttpGet]
        [Route("api/vuelo/getbyfecha/{fechainicio}/{fechafin}")]
        public IHttpActionResult GetByFecha(string fechainicio, string fechafin)
        {
            ML.Result result = BL.Vuelo.GetByFecha(fechainicio, fechafin);
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NoContent, result);
            }
        }

        [HttpGet]
        [Route("api/vuelo/getall")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Vuelo.GetAll();

            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        //[HttpPost]
        
        //// GET: api/Vuelo
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Vuelo/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Vuelo
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Vuelo/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Vuelo/5
        //public void Delete(int id)
        //{
        //}
    }
}
