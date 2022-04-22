using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Condition
    {
        public Condition()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdCondition { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
