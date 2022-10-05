using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Tiempo
    {
        public Tiempo()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public string IdFecha { get; set; }
        public DateTime? Fecha { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
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
