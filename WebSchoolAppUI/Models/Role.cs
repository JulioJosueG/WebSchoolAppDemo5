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

        public virtual ICollection<Perfile> Perfiles { get; set; }
    }
}
