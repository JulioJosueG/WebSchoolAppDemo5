using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class File
    {
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public DateTime? Date { get; set; }
        public string Route { get; set; }
        public int? IdState { get; set; }
        public int? IdSchoolYear { get; set; }

        public virtual SchoolYear IdSchoolYearNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
    }
}
