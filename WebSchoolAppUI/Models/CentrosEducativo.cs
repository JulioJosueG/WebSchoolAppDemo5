using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class CentrosEducativo
    {
        public CentrosEducativo()
        {
            CentrosProfesores = new HashSet<CentrosProfesore>();
            CursosProfesores = new HashSet<CursosProfesore>();
            Departamentos = new HashSet<Departamento>();
            Estudiantes = new HashSet<Estudiante>();
            FactInscripcions = new HashSet<FactInscripcion>();
            PersonalCentros = new HashSet<PersonalCentro>();
            Profesores = new HashSet<Profesore>();
        }

        public int IdCentroEducativo { get; set; }
        [Required (ErrorMessage = "Nombre del centro es requerido.")]
        [Display(Name = "Nombre del Centro")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Tipo del centro es requerido.")]
        [Display(Name = "Tipo de Centro")]
        public int IdTipoCentro { get; set; }
        [Required(ErrorMessage = "Distrito es requerido")]
        [Display(Name = "Distrito")]
        public int IdDistrito { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        [Display(Name = "Distrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }
        [Display(Name = "Tipo de Centro")]
        public virtual TipoCentro IdTipoCentroNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<CentrosProfesore> CentrosProfesores { get; set; }
        public virtual ICollection<CursosProfesore> CursosProfesores { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentros { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
    }
}
