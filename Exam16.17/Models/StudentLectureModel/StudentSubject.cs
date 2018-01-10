using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam16._17.Models.StudentLectureModel
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        [Key, Column(Order = 1)]
        [ForeignKey("assocStudent")]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("assocSubject")]
        [Display(Name = "Subject ID")]
        public int SubjectId { get; set; }

        public virtual Student assocStudent { get; set; }
        public virtual Subject assocSubject { get; set; }
    }
}