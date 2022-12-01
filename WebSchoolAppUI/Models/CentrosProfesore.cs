using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class CentrosProfesore
    {
        public int IdCentroProf { get; set; }
        public int? Profesor { get; set; }
        public int? Centro { get; set; }
        public int? CreadoPor { get; set; }
        public DateTime? FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual CentrosEducativo CentroNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual Profesore ProfesorNavigation { get; set; }
    }
}
