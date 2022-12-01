using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }

        public virtual Estado EstadoNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
