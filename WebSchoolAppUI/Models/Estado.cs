using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Estado
    {
        public Estado()
        {
            AnioEscolars = new HashSet<AnioEscolar>();
            Asignaturas = new HashSet<Asignatura>();
            CentrosEducativos = new HashSet<CentrosEducativo>();
            CentrosProfesores = new HashSet<CentrosProfesore>();
            Condiciones = new HashSet<Condicione>();
            Cursos = new HashSet<Curso>();
            CursosProfesores = new HashSet<CursosProfesore>();
            Departamentos = new HashSet<Departamento>();
            Distritos = new HashSet<Distrito>();
            Estudiantes = new HashSet<Estudiante>();
            EstudiantesTipos = new HashSet<EstudiantesTipo>();
            FactInscripcions = new HashSet<FactInscripcion>();
            ModalidadesTipos = new HashSet<ModalidadesTipo>();
            Niveles = new HashSet<Nivele>();
            Perfiles = new HashSet<Perfile>();
            PersonalCentros = new HashSet<PersonalCentro>();
            PersonalDistritos = new HashSet<PersonalDistrito>();
            Profesores = new HashSet<Profesore>();
            Roles = new HashSet<Role>();
            TipoUsuarios = new HashSet<TipoUsuario>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<AnioEscolar> AnioEscolars { get; set; }
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativos { get; set; }
        public virtual ICollection<CentrosProfesore> CentrosProfesores { get; set; }
        public virtual ICollection<Condicione> Condiciones { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<CursosProfesore> CursosProfesores { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<EstudiantesTipo> EstudiantesTipos { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
        public virtual ICollection<ModalidadesTipo> ModalidadesTipos { get; set; }
        public virtual ICollection<Nivele> Niveles { get; set; }
        public virtual ICollection<Perfile> Perfiles { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentros { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritos { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<TipoUsuario> TipoUsuarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
