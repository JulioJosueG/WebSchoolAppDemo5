using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Student
    {
        public Student()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Idsigerd { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
