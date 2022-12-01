using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class CursosProfesore
    {
        public int IdCursoProf { get; set; }
        public int? Curso { get; set; }
        public int? Profesor { get; set; }
        public int? Centro { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreado { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual CentrosEducativo CentroNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Curso CursoNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual Profesore ProfesorNavigation { get; set; }
    }
}
