using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Curso")]
    public partial class Curso
    {
        public Curso()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
        }

        [Key]
        public int IdCurso { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
        public int? Seccion { get; set; }
        public int? Nivel { get; set; }
        public int? Profesor { get; set; }

        [ForeignKey(nameof(Nivel))]
        [InverseProperty("Cursos")]
        public virtual Nivel NivelNavigation { get; set; }
        [ForeignKey(nameof(Profesor))]
        [InverseProperty("Cursos")]
        public virtual Profesor ProfesorNavigation { get; set; }
        [ForeignKey(nameof(Seccion))]
        [InverseProperty("Cursos")]
        public virtual Seccion SeccionNavigation { get; set; }
        [InverseProperty(nameof(EstudianteCurso.CursoNavigation))]
        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
