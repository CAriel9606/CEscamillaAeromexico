using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public ML.Tipo Tipo { get; set; }
    }
}
