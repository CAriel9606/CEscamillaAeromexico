using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pasajero.Controllers
{
    public class PasajeroController : ApiController
    {

        [HttpPost]
        [Route("api/pasajero/add")]
        public IHttpActionResult Add([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NoContent, result);
            }
        }



        //// GET: api/Pasajero
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Pasajero/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Pasajero
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Pasajero/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Pasajero/5
        //public void Delete(int id)
        //{
        //}
    }
}
