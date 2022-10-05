using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Nivele
    {
        public Nivele()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdNivel { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
