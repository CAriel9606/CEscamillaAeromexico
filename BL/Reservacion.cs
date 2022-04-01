using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Reservacion
    {
        public static ML.Result ReservacionAdd(ML.Reservacion reservacion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.CEscamillaAeroMexicoEntities context = new DL.CEscamillaAeroMexicoEntities())
                {
                    foreach(var list in reservacion.Reservaciones)
                    {
                        var resultQuery = context.ReservacionAdd(list.Vuelo.NumeroVuelo, list.Pasajero.IdPasajero);

                        if(resultQuery>=1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido Insertar la Reservacion";
                        }
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
