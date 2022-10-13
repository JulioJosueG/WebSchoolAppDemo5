using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class PersonalDistrito
    {
        public int IdPersonalDistrito { get; set; }
        [Required,MinLength(3),MaxLength(20)]
        public string Nombre { get; set; }
        [Required,MinLength(3),MaxLength(20)]
        public string Apellido { get; set; }
        [Required, MaxLength(11)]
        public string Cedula { get; set; }
        [Required]
        public int? IdDepartamento { get; set; }
        [Required]
        public int IdDistrito { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
