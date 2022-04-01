using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Login(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL.CEscamillaAeroMexicoEntities context = new DL.CEscamillaAeroMexicoEntities())
                {
                    var query = context.GetByUserName(usuario.UserName).FirstOrDefault();
                    if (query != null)
                    {
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Correo = query.Correo;
                        usuario.Contrasenia = query.Contrasenia;
                        usuario.Tipo = new ML.Tipo();
                        usuario.Tipo.IdTipo = query.IdTipo.Value;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Credenciales erroneas o usuario inexistente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
