using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Profesores = new HashSet<Profesore>();
        }

        public int IdAsignatura { get; set; }
        public string Nombre { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
