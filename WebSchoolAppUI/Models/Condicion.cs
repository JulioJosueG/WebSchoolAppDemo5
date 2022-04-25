using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebSchoolAppUI.Models
{
    [Table("Condicion")]
    public partial class Condicion
    {
        public Condicion()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        public int IdCondicion { get; set; }
        [StringLength(100)]
        public string NombreCondicion { get; set; }

        [InverseProperty(nameof(Estudiante.CondicionNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
