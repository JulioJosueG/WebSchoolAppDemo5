using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class Time
    {
        public Time()
        {
            FactSignOns = new HashSet<FactSignOn>();
        }

        public string IdDate { get; set; }
        public DateTime? Date { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
    }
}
