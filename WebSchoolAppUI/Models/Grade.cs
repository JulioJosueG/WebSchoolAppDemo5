using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Grade
    {
        public Grade()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdGrade { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Level { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
