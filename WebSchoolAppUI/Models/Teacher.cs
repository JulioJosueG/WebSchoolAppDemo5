using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdTeacher { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
