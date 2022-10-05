using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AnioEscolarCreadoPorNavigations = new HashSet<AnioEscolar>();
            AnioEscolarModificadoPorNavigations = new HashSet<AnioEscolar>();
            AsignaturaCreadoPorNavigations = new HashSet<Asignatura>();
            AsignaturaModificadoPorNavigations = new HashSet<Asignatura>();
            CentrosEducativoCreadoPorNavigations = new HashSet<CentrosEducativo>();
            CentrosEducativoModificadoPorNavigations = new HashSet<CentrosEducativo>();
            CondicioneCreadoPorNavigations = new HashSet<Condicione>();
            CondicioneModificadoPorNavigations = new HashSet<Condicione>();
            DepartamentoCreadoPorNavigations = new HashSet<Departamento>();
            DepartamentoModificadoPorNavigations = new HashSet<Departamento>();
            DistritoCreadoPorNavigations = new HashSet<Distrito>();
            DistritoModificadoPorNavigations = new HashSet<Distrito>();
            EstadoCreadoPorNavigations = new HashSet<Estado>();
            EstadoModificadoPorNavigations = new HashSet<Estado>();
            EstudianteCreadoPorNavigations = new HashSet<Estudiante>();
            EstudianteModificadoPorNavigations = new HashSet<Estudiante>();
            FactInscripcionCreadoPorNavigations = new HashSet<FactInscripcion>();
            FactInscripcionModificadoPorNavigations = new HashSet<FactInscripcion>();
            PersonalCentroCreadoPorNavigations = new HashSet<PersonalCentro>();
            PersonalCentroModificadoPorNavigations = new HashSet<PersonalCentro>();
            PersonalDistritoCreadoPorNavigations = new HashSet<PersonalDistrito>();
            PersonalDistritoModificadoPorNavigations = new HashSet<PersonalDistrito>();
            ProfesoreCreadoPorNavigations = new HashSet<Profesore>();
            ProfesoreModificadoPorNavigations = new HashSet<Profesore>();
            TiempoCreadoPorNavigations = new HashSet<Tiempo>();
            TiempoModificadoPorNavigations = new HashSet<Tiempo>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual ICollection<AnioEscolar> AnioEscolarCreadoPorNavigations { get; set; }
        public virtual ICollection<AnioEscolar> AnioEscolarModificadoPorNavigations { get; set; }
        public virtual ICollection<Asignatura> AsignaturaCreadoPorNavigations { get; set; }
        public virtual ICollection<Asignatura> AsignaturaModificadoPorNavigations { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativoCreadoPorNavigations { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativoModificadoPorNavigations { get; set; }
        public virtual ICollection<Condicione> CondicioneCreadoPorNavigations { get; set; }
        public virtual ICollection<Condicione> CondicioneModificadoPorNavigations { get; set; }
        public virtual ICollection<Departamento> DepartamentoCreadoPorNavigations { get; set; }
        public virtual ICollection<Departamento> DepartamentoModificadoPorNavigations { get; set; }
        public virtual ICollection<Distrito> DistritoCreadoPorNavigations { get; set; }
        public virtual ICollection<Distrito> DistritoModificadoPorNavigations { get; set; }
        public virtual ICollection<Estado> EstadoCreadoPorNavigations { get; set; }
        public virtual ICollection<Estado> EstadoModificadoPorNavigations { get; set; }
        public virtual ICollection<Estudiante> EstudianteCreadoPorNavigations { get; set; }
        public virtual ICollection<Estudiante> EstudianteModificadoPorNavigations { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcionCreadoPorNavigations { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcionModificadoPorNavigations { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentroCreadoPorNavigations { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentroModificadoPorNavigations { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritoCreadoPorNavigations { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritoModificadoPorNavigations { get; set; }
        public virtual ICollection<Profesore> ProfesoreCreadoPorNavigations { get; set; }
        public virtual ICollection<Profesore> ProfesoreModificadoPorNavigations { get; set; }
        public virtual ICollection<Tiempo> TiempoCreadoPorNavigations { get; set; }
        public virtual ICollection<Tiempo> TiempoModificadoPorNavigations { get; set; }
    }
}
