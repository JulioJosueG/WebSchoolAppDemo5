using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            CentrosEducativos = new HashSet<CentrosEducativo>();
            Departamentos = new HashSet<Departamento>();
            PersonalDistritos = new HashSet<PersonalDistrito>();
        }

        public int IdDistrito { get; set; }
        public string Codigo { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdMunicipio { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativos { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritos { get; set; }
    }
}
