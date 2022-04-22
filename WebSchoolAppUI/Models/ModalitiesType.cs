using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class ModalitiesType
    {
        public ModalitiesType()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdModalityType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
