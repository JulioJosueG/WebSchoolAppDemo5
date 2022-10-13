using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdSexo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
