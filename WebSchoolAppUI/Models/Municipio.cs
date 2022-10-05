using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Distritos = new HashSet<Distrito>();
        }

        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
