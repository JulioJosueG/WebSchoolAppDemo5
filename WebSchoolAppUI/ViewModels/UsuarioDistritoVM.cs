using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.ViewModels
{
    public class UsuarioDistritoVM
    {
        public int IdUsuario { get; set; }
        public string Perfil { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public int? Estado { get; set; }
        public string Personal { get; set; }
        public string TipoUsuario { get; set; }
        public string Distrito { get; set; }

    }
}
