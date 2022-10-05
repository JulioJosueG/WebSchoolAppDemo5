using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Archivos = new HashSet<Archivo>();
            ArchivosDetalles = new HashSet<ArchivosDetalle>();
            ValidacionData = new HashSet<ValidacionDatum>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificado { get; set; }

        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
        public virtual ICollection<ArchivosDetalle> ArchivosDetalles { get; set; }
        public virtual ICollection<ValidacionDatum> ValidacionData { get; set; }
    }
}
