using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Archivo
    {
        public Archivo()
        {
            ArchivosDetalles = new HashSet<ArchivosDetalle>();
            ValidacionData = new HashSet<ValidacionDatum>();
        }

        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Ruta { get; set; }
        public int? IdEstado { get; set; }
        public int? IdAnioEscolar { get; set; }
        public int? IdDistrito { get; set; }
        public int? IdCentro { get; set; }

        public virtual AnioEscolar IdAnioEscolarNavigation { get; set; }
        public virtual CentrosEducativo IdCentroNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<ArchivosDetalle> ArchivosDetalles { get; set; }
        public virtual ICollection<ValidacionDatum> ValidacionData { get; set; }
    }
}
