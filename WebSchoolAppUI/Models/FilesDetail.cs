using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class FilesDetail
    {
        public int IdFileDetail { get; set; }
        public int? IdFile { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Modality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Condition { get; set; }
        public string Course { get; set; }
        public int? IdState { get; set; }
        public string StudentId { get; set; }
        public string Comment { get; set; }
        public string Idsigerd { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        public virtual State IdStateNavigation { get; set; }
    }
}
