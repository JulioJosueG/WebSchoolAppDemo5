using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class ModalidadesTipo
    {
        public ModalidadesTipo()
        {
            FactInscripcions = new HashSet<FactInscripcion>();
        }

        public int IdModalidadTipo { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }

        public virtual Estado EstadoNavigation { get; set; }
        public virtual ICollection<FactInscripcion> FactInscripcions { get; set; }
    }
}
