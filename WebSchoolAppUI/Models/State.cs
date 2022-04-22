using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class State
    {
        public State()
        {
            Files = new HashSet<File>();
            FilesDetails = new HashSet<FilesDetail>();
        }

        public int IdState { get; set; }
        public string Name { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FilesDetail> FilesDetails { get; set; }
    }
}
