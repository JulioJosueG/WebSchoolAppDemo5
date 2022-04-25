using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Sexo")]
    public partial class Sexo
    {
        public Sexo()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        public int IdSexo { get; set; }
        [StringLength(100)]
        public string NombreSexo { get; set; }

        [InverseProperty(nameof(Estudiante.SexoNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
