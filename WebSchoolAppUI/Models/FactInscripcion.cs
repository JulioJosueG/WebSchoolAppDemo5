using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class FactInscripcion
    {
        public int IdFactInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int? IdEstudianteTipo { get; set; }
        public int? IdModalidadTipo { get; set; }
        public int? IdAnioEscolar { get; set; }
        public int? IdCurso { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdEdad { get; set; }
        public int? IdCondicion { get; set; }
        public int? IdCentro { get; set; }
        public int? ImporteInscripcion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Estado EstadoNavigation { get; set; }
        public virtual AnioEscolar IdAnioEscolarNavigation { get; set; }
        public virtual CentrosEducativo IdCentroNavigation { get; set; }
        public virtual Condicione IdCondicionNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Edade IdEdadNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual EstudiantesTipo IdEstudianteTipoNavigation { get; set; }
        public virtual ModalidadesTipo IdModalidadTipoNavigation { get; set; }
        public virtual Profesore IdProfesorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
    }
}
