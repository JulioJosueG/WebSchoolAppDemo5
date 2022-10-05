using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Distritos = new HashSet<Distrito>();
            Municipios = new HashSet<Municipio>();
        }

        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
