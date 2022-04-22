using System;
using System.Collections.Generic;

#nullable disable

namespace WebSchoolAppUI.Models
{
    public partial class FactSignOn
    {
        public int IdFactSignOn { get; set; }
        public int IdStudent { get; set; }
        public int? IdStudentType { get; set; }
        public int? IdModalityType { get; set; }
        public string IdDate { get; set; }
        public int? IdSchoolYear { get; set; }
        public int? IdGrade { get; set; }
        public int? IdTeacher { get; set; }
        public int? IdAge { get; set; }
        public int? IdCondition { get; set; }
        public int? SignOnAnualImport { get; set; }

        public virtual Age IdAgeNavigation { get; set; }
        public virtual Condition IdConditionNavigation { get; set; }
        public virtual Time IdDateNavigation { get; set; }
        public virtual Grade IdGradeNavigation { get; set; }
        public virtual ModalitiesType IdModalityTypeNavigation { get; set; }
        public virtual SchoolYear IdSchoolYearNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
        public virtual StudentsType IdStudentTypeNavigation { get; set; }
        public virtual Teacher IdTeacherNavigation { get; set; }
    }
}
