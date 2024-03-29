﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            CentrosProfesoreCreadoPorNavigations = new HashSet<CentrosProfesore>();
            CentrosProfesoreModificadoPorNavigations = new HashSet<CentrosProfesore>();
            CondicioneCreadoPorNavigations = new HashSet<Condicione>();
            CondicioneModificadoPorNavigations = new HashSet<Condicione>();
            CursosProfesoreCreadoPorNavigations = new HashSet<CursosProfesore>();
            CursosProfesoreModificadoPorNavigations = new HashSet<CursosProfesore>();
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
            PerfileCreadoPorNavigations = new HashSet<Perfile>();
            PerfileModificadoPorNavigations = new HashSet<Perfile>();
            PersonalCentroCreadoPorNavigations = new HashSet<PersonalCentro>();
            PersonalCentroModificadoPorNavigations = new HashSet<PersonalCentro>();
            PersonalDistritoCreadoPorNavigations = new HashSet<PersonalDistrito>();
            PersonalDistritoModificadoPorNavigations = new HashSet<PersonalDistrito>();
            ProfesoreCreadoPorNavigations = new HashSet<Profesore>();
            ProfesoreModificadoPorNavigations = new HashSet<Profesore>();
            RoleCreadoPorNavigations = new HashSet<Role>();
            RoleModificadoPorNavigations = new HashSet<Role>();
        }

        public int IdUsuario { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime? FechaModificado { get; set; }
        public string Contrasena { get; set; }
        [Required]
        public int? Perfil { get; set; }
        [Required(ErrorMessage ="Falta ingresar el nombre de usuario"), MinLength(3, ErrorMessage ="Nombre de usuario menor a 3 caracteres"), MaxLength(20,ErrorMessage ="Nombre de usuario mayor a 20 caracteres")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage ="Falta ingresar el el correo")]
        public string Correo { get; set; }
        public int? Estado { get; set; }
        public int? Personal { get; set; }
        public int? TipoUsuario { get; set; }

        public virtual Estado EstadoNavigation { get; set; }
        public virtual Perfile PerfilNavigation { get; set; }
        public virtual TipoUsuario TipoUsuarioNavigation { get; set; }
        public virtual ICollection<AnioEscolar> AnioEscolarCreadoPorNavigations { get; set; }
        public virtual ICollection<AnioEscolar> AnioEscolarModificadoPorNavigations { get; set; }
        public virtual ICollection<Asignatura> AsignaturaCreadoPorNavigations { get; set; }
        public virtual ICollection<Asignatura> AsignaturaModificadoPorNavigations { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativoCreadoPorNavigations { get; set; }
        public virtual ICollection<CentrosEducativo> CentrosEducativoModificadoPorNavigations { get; set; }
        public virtual ICollection<CentrosProfesore> CentrosProfesoreCreadoPorNavigations { get; set; }
        public virtual ICollection<CentrosProfesore> CentrosProfesoreModificadoPorNavigations { get; set; }
        public virtual ICollection<Condicione> CondicioneCreadoPorNavigations { get; set; }
        public virtual ICollection<Condicione> CondicioneModificadoPorNavigations { get; set; }
        public virtual ICollection<CursosProfesore> CursosProfesoreCreadoPorNavigations { get; set; }
        public virtual ICollection<CursosProfesore> CursosProfesoreModificadoPorNavigations { get; set; }
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
        public virtual ICollection<Perfile> PerfileCreadoPorNavigations { get; set; }
        public virtual ICollection<Perfile> PerfileModificadoPorNavigations { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentroCreadoPorNavigations { get; set; }
        public virtual ICollection<PersonalCentro> PersonalCentroModificadoPorNavigations { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritoCreadoPorNavigations { get; set; }
        public virtual ICollection<PersonalDistrito> PersonalDistritoModificadoPorNavigations { get; set; }
        public virtual ICollection<Profesore> ProfesoreCreadoPorNavigations { get; set; }
        public virtual ICollection<Profesore> ProfesoreModificadoPorNavigations { get; set; }
        public virtual ICollection<Role> RoleCreadoPorNavigations { get; set; }
        public virtual ICollection<Role> RoleModificadoPorNavigations { get; set; }
    }
}
