using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Perfile
    {
        public Perfile()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public int? Rol { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual Role RolNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
