using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.ViewModels
{
    public class UsuarioVM
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Nombre { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string Apellido { get; set; }
        [Required, MinLength(8),EmailAddress, MaxLength(40)]
        public string Correo { get; set; }
        [Required, MinLength(8), MaxLength(20)]
        public string Contrasena { get; set; }
        [Required]
        public int Perfil { get; set; }

        [Required, MinLength(6), MaxLength(20)]
        public string NombreUsuario { get; set; }

    }
}
