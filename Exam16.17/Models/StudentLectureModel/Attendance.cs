using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam16._17.Models.StudentLectureModel
{
    [Table("Attendance")]
    public class Attendance 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Attendance ID")]
        public int AttendanceId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Attendance Date")]
        public DateTime? AttendanceDate { get; set; }

        [Display(Name = "Subject ID")]
        [ForeignKey("assocSubject")]
        public int SubjectId { get; set; }

        [Display(Name = "Student ID")]
        [ForeignKey("assocStudent")]
        public string StudentId { get; set; }

        [Display(Name = "Present")]
        public bool Present { get; set; }

        public virtual Subject assocSubject { get; set; }

        public virtual Student assocStudent { get; set; }
    }
}