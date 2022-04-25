using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Seccion")]
    public partial class Seccion
    {
        public Seccion()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdSeccion { get; set; }
        [StringLength(100)]
        public string NombreSeccion { get; set; }

        [InverseProperty(nameof(Curso.SeccionNavigation))]
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
