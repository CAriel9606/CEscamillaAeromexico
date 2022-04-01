using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pasajero.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Login(usuario);
            usuario=(ML.Usuario)result.Object;
            if (result.Correct)
            {
                if(usuario.Tipo.IdTipo==1)
                {
                    return Content(HttpStatusCode.OK, result);
                }
                else
                {
                    return Content(HttpStatusCode.Unauthorized, result);
                }
                
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Login/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Login
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Login/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Login/5
        //public void Delete(int id)
        //{
        //}
    }
}
