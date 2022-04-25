using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Nivel")]
    public partial class Nivel
    {
        public Nivel()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdNivel { get; set; }
        [StringLength(100)]
        public string NombreNivel { get; set; }

        [InverseProperty(nameof(Curso.NivelNavigation))]
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
