using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("EstudianteCurso")]
    public partial class EstudianteCurso
    {
        [Key]
        public int IdSigerd { get; set; }
        [Key]
        public int Curso { get; set; }

        [ForeignKey(nameof(Curso))]
        [InverseProperty("EstudianteCursos")]
        public virtual Curso CursoNavigation { get; set; }
        [ForeignKey(nameof(IdSigerd))]
        [InverseProperty(nameof(Estudiante.EstudianteCursos))]
        public virtual Estudiante IdSigerdNavigation { get; set; }
    }
}
