using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class AnioEscolar
    {
        public AnioEscolar()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdAnioEscolar { get; set; }
        public string Anio { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
