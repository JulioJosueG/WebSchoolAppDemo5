using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class CentrosEducativo
    {
        public CentrosEducativo()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
            PersonalCentros = new HashSet<PersonalCentro>();
            Profesores = new HashSet<Profesore>();
        }

        public int IdCentroEducativo { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCentro { get; set; }
        public int IdDistrito { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual TipoCentro IdTipoCentroNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentros { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
