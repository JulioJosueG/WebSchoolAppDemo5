using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            CentrosProfesores = new HashSet<CentrosProfesore>();
            CursosProfesores = new HashSet<CursosProfesore>();
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public int? IdAsignatura { get; set; }
        public int? IdCentro { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Asignatura IdAsignaturaNavigation { get; set; }
        public virtual CentrosEducativo IdCentroNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<CentrosProfesore> CentrosProfesores { get; set; }
        public virtual ICollection<CursosProfesore> CursosProfesores { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
