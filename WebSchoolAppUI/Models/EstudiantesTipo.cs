using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class EstudiantesTipo
    {
        public EstudiantesTipo()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdEstudianteTipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
