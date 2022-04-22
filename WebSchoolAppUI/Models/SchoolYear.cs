﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            FactSignOns = new HashSet<FactSignOn>();
            Files = new HashSet<File>();
        }

        public int IdSchoolYear { get; set; }
        public string Year { get; set; }

        public virtual ICollection<FactSignOn> FactSignOns { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
