using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class PersonalDistrito
    {
        public int IdPersonalDistrito { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public int? IdDepartamento { get; set; }
        public int IdDistrito { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
