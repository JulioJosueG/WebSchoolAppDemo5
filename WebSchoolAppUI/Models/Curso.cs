using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public int? IdSeccion { get; set; }
        public int? IdNivel { get; set; }

        public virtual Nivele IdNivelNavigation { get; set; }
        public virtual Seccione IdSeccionNavigation { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
