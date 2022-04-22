using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class StudentsType
    {
        public StudentsType()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdStudentType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
