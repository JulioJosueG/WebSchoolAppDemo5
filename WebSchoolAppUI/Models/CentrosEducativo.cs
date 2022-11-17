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
            Archivos = new HashSet<Archivo>();
            FactInscripcions = new HashSet<FactInscripcion>();
            PersonalCentros = new HashSet<PersonalCentro>();
            Profesores = new HashSet<Profesore>();
        }

        public int IdCentroEducativo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Tipo Centro")]

        public int IdTipoCentro { get; set; }
        [DisplayName("Distrito")]
        public int IdDistrito { get; set; }
        [DisplayName("Creado Por")]
        public int CreadoPor { get; set; }
        [DisplayName("Fecha Creacion")]
        public DateTime FechaCreado { get; set; }
        [DisplayName("Modificado Por")]
        public int? ModificadoPor { get; set; }
        [DisplayName("Fecha de Modificación")]
        public DateTime? FechaModificado { get; set; }
        [DisplayName("Creado Por")]
        public virtual Usuario CreadoPorNavigation { get; set; }
        [DisplayName("Distrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }
        [DisplayName("Tipo Centro")]
        public virtual TipoCentro IdTipoCentroNavigation { get; set; }
        [DisplayName("Modificado Por")]
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentros { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
        public virtual ICollection<Departamento> DepartamentoCentroNavigations { get; set; }

    }
}
