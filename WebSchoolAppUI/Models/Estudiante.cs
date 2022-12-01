using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Idsigerd { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Sexo { get; set; }
        public int? Centro { get; set; }
        public int? Estado { get; set; }

        public virtual CentrosEducativo CentroNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual Sexo SexoNavigation { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
