using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Edade
    {
        public Edade()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdEdad { get; set; }
        public string RangoEdad { get; set; }
        public string Edad { get; set; }

        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
