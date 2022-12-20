using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string NombreArchivo { get; set; }
        [Required]
        public DateTime? Fecha { get; set; }
        [Required]
        public string Ruta { get; set; }
        [Required]
        public int? IdEstado { get; set; }
        [Required]
        public int? IdAnioEscolar { get; set; }
        [Required]
        public int? IdDistrito { get; set; }
        [Required]
        public int? IdCentro { get; set; }

        public virtual AnioEscolar IdAnioEscolarNavigation { get; set; }
        public virtual CentrosEducativo IdCentroNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<ArchivosDetalle> ArchivosDetalles { get; set; }
        public virtual ICollection<ValidacionDatum> ValidacionData { get; set; }
    }
}
