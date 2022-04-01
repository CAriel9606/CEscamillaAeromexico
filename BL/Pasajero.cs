using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result Add(ML.Pasajero pasajero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.CEscamillaAeroMexicoEntities context = new DL.CEscamillaAeroMexicoEntities())
                {
                    var query = context.PasajeroAdd(pasajero.Nombre, pasajero.ApellidoPaterno, pasajero.ApellidoMaterno);

                    if(query>=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El Pasajero no se ha podido ingresar correctamente";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }
    }
}
