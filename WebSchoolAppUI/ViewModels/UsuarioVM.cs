using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.ViewModels
{
    public class UsuarioVM
    {
        [Required, MinLength(3)]
        public string Nombre { get; set; }
        [Required, MinLength(3)]
        public string Apellido { get; set; }
    }
}
