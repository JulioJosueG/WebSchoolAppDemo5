using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.ViewModels
{
    public class UsuarioAuth
    {
        [Required, MinLength(6), MaxLength(20)]
        public string NombreUsuario { get; set; }
        [Required, MinLength(8), MaxLength(20)]
        public string Contrasena { get; set; }
    }
}
