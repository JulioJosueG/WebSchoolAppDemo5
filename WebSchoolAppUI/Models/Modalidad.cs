using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Modalidad")]
    public partial class Modalidad
    {
        public Modalidad()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        public int IdModalidad { get; set; }
        [StringLength(100)]
        public string NombreModalidad { get; set; }

        [InverseProperty(nameof(Estudiante.ModalidadNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
