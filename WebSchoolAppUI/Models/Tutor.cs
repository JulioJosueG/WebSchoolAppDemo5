using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Tutor")]
    public partial class Tutor
    {
        public Tutor()
        {
            EstudianteMadreNavigations = new HashSet<Estudiante>();
            EstudiantePadreNavigations = new HashSet<Estudiante>();
        }

        [Key]
        public int IdTutor { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(20)]
        public string Contacto { get; set; }

        [InverseProperty(nameof(Estudiante.MadreNavigation))]
        public virtual ICollection<Estudiante> EstudianteMadreNavigations { get; set; }
        [InverseProperty(nameof(Estudiante.PadreNavigation))]
        public virtual ICollection<Estudiante> EstudiantePadreNavigations { get; set; }
    }
}
