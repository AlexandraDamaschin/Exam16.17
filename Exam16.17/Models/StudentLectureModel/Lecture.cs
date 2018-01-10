using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam16._17.Models.StudentLectureModel
{
    [Table("Lecture")]
    public class Lecture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Lecture ID")]
        public int LectureId { get; set; }

        [Display(Name = "Lecture Name")]
        public string LectureName { get; set; }

        public virtual ICollection<LectureSubject> lectureSubjects { get; set; }
    }
}