using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Seccione
    {
        public Seccione()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdSeccion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
