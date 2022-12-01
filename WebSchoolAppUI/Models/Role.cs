using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Role
    {
        public Role()
        {
            Perfiles = new HashSet<Perfile>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Perfile> Perfiles { get; set; }
    }
}
