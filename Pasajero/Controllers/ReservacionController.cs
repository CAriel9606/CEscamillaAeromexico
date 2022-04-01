using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pasajero.Controllers
{
    public class ReservacionController : ApiController
    {

        [HttpPost]
        [Route("api/reservacion/add")]
        public IHttpActionResult Add([FromBody] ML.Reservacion reservacion)
        {
            ML.Result result = BL.Reservacion.ReservacionAdd(reservacion);
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }



        //// GET: api/Reservacion
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Reservacion/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Reservacion
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Reservacion/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Reservacion/5
        //public void Delete(int id)
        //{
        //}
    }
}
