using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Falta ingresar el nombre"), MinLength(3, ErrorMessage = "Nombre menor a 3 caracteres"), MaxLength(20, ErrorMessage = "Nombre mayor a 20 caracteres")]
        public string Nombre { get; set; }
             [Required(ErrorMessage = "Falta ingresar el apellido"), MinLength(3, ErrorMessage = "Apellido menor a 3 caracteres"), MaxLength(20, ErrorMessage = "Apellido mayor a 20 caracteres")]

        public string Apellido { get; set; }
        [Required(ErrorMessage ="Ingresar Idsigerd")]
        public string Idsigerd { get; set; }
        [Required,DateValidation(ErrorMessage ="Fecha Invalida")]
        public DateTime? FechaNacimiento { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        [Required(ErrorMessage ="Falta ingresar el Sexo")]
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
