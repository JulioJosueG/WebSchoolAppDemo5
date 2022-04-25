using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        public int IdEstado { get; set; }
        [StringLength(100)]
        public string NombreEstado { get; set; }

        [InverseProperty(nameof(Estudiante.EstadoNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
