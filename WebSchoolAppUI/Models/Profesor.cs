using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Profesor")]
    public partial class Profesor
    {
        public Profesor()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdProfesor { get; set; }
        [StringLength(100)]
        public string NombreProfesor { get; set; }
        [StringLength(100)]
        public string ApellidoProfesor { get; set; }

        [InverseProperty(nameof(Curso.ProfesorNavigation))]
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
