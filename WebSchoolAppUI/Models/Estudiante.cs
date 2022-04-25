using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Estudiante")]
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
        }

        [Key]
        public int IdSigerd { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string Apellido { get; set; }
        public int? Sexo { get; set; }
        [StringLength(20)]
        public string Contacto { get; set; }
        public int? Estado { get; set; }
        public int? Modalidad { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }
        public int? Condicion { get; set; }
        public int? Padre { get; set; }
        public int? Madre { get; set; }

        [ForeignKey(nameof(Condicion))]
        [InverseProperty("Estudiantes")]
        public virtual Condicion CondicionNavigation { get; set; }
        [ForeignKey(nameof(Estado))]
        [InverseProperty("Estudiantes")]
        public virtual Estado EstadoNavigation { get; set; }
        [ForeignKey(nameof(Madre))]
        [InverseProperty(nameof(Tutor.EstudianteMadreNavigations))]
        public virtual Tutor MadreNavigation { get; set; }
        [ForeignKey(nameof(Modalidad))]
        [InverseProperty("Estudiantes")]
        public virtual Modalidad ModalidadNavigation { get; set; }
        [ForeignKey(nameof(Padre))]
        [InverseProperty(nameof(Tutor.EstudiantePadreNavigations))]
        public virtual Tutor PadreNavigation { get; set; }
        [ForeignKey(nameof(Sexo))]
        [InverseProperty("Estudiantes")]
        public virtual Sexo SexoNavigation { get; set; }
        [InverseProperty(nameof(EstudianteCurso.IdSigerdNavigation))]
        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
