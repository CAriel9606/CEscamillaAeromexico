using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result GetByFecha(string fechaInicio, string fechaFin)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.CEscamillaAeroMexicoEntities context = new DL.CEscamillaAeroMexicoEntities())
                {
                    var query = context.GetVuelos(fechaInicio, fechaFin);
                    result.Objects = new List<object>();

                    if(query!=null)
                    {
                        foreach(var list in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();
                            vuelo.NumeroVuelo = list.NumeroVuelo;
                            vuelo.Origen = list.Origen;
                            vuelo.Destino = list.Destino;
                            vuelo.FechaSalida = Convert.ToDateTime(list.FechaSalida);

                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron datos con esa informacion";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.CEscamillaAeroMexicoEntities context = new DL.CEscamillaAeroMexicoEntities())
                {
                    var query = context.GetAllVuelos().ToList();
                    result.Objects = new List<object>();

                    if(query!=null)
                    {
                        foreach(var list in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();

                            vuelo.NumeroVuelo = list.NumeroVuelo;
                            vuelo.Origen = list.Origen;
                            vuelo.Destino = list.Destino;
                            vuelo.FechaSalida =Convert.ToDateTime(list.FechaSalida);

                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha encontrado informacion en la tabla";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage=ex.Message;
                result.Ex=ex;
            }
            return result;
        }
    }
}
