using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class TipoCentro
    {
        public TipoCentro()
        {
            CentrosEducativos = new HashSet<CentrosEducativo>();
        }

        public int IdTipoCentro { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CentrosEducativo> CentrosEducativos { get; set; }
    }
}
