using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Age
    {
        public Age()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdAge { get; set; }
        public string Range { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
