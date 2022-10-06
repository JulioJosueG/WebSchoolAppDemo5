using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class CentrosEducativo
    {
        public CentrosEducativo()
        {
            PersonalCentros = new HashSet<PersonalCentro>();
        }

        public int IdCentroEducativo { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Tipo Centro")]
        public int IdTipoCentro { get; set; }
        [DisplayName("Distrito")]
        public int IdDistrito { get; set; }
        [DisplayName("Creado Por")]
        public int CreadoPor { get; set; }
        [DisplayName("Fecha Creado")]

        public DateTime FechaCreado { get; set; }
        [DisplayName("Modificado Por")]
        public int? ModificadoPor { get; set; }
        [DisplayName("Fecha Modificado")]
        public DateTime? FechaModificado { get; set; }

        public virtual ICollection<PersonalCentro> PersonalCentros { get; set; }
    }
}
