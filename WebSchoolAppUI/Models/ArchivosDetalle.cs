using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class ArchivosDetalle
    {
        public ArchivosDetalle()
        {
            ValidacionData = new HashSet<ValidacionDatum>();
        }

        public int IdArchivoDetalle { get; set; }
        public int? IdArchivo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Modalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Condicion { get; set; }
        public string Curso { get; set; }
        public int? IdEstado { get; set; }
        public int? Profesor { get; set; }
        public string IdSigerd { get; set; }
        public string Comment { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }

        public virtual Archivo IdArchivoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<ValidacionDatum> ValidacionData { get; set; }
    }
}
