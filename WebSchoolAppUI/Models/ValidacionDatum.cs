using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class ValidacionDatum
    {
        public int IdValidacion { get; set; }
        public int? IdArchivo { get; set; }
        public int? IdArchivoDetalle { get; set; }
        public int? IdEstado { get; set; }
        public string Comment { get; set; }

        public virtual ArchivosDetalle IdArchivoDetalleNavigation { get; set; }
        public virtual Archivo IdArchivoNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
