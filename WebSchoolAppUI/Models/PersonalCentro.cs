using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class PersonalCentro
    {
        public int IdPersonalCentro { get; set; }
        [Required(ErrorMessage = "Falta ingresar el nombre"), MinLength(3, ErrorMessage = "Nombre menor a 3 caracteres"), MaxLength(20, ErrorMessage = "Nombre mayor a 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Falta ingresar el apellido"), MinLength(3, ErrorMessage = "Apellido menor a 3 caracteres"), MaxLength(20, ErrorMessage = "Apellido mayor a 20 caracteres")]
        public string Apellido { get; set; }
        [Required, MinLength(11, ErrorMessage = "Cedula Invalida"), MaxLength(11, ErrorMessage = "Limite de caracteres pasado")]
        public string Cedula { get; set; }
        [Required]
        public int? IdDepartamento { get; set; }
        public int IdCentro { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual CentrosEducativo IdCentroNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
