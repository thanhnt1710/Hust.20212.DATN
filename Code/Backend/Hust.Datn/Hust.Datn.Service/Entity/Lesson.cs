using Hust.Datn.Service.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    [View(MaxID = "Lesson_GetMaxID.sql")]
    public class Lesson
    {
        public int LessonID { get; set; }
        public string LessonName { get; set; }
        public int LessonPrevID { get; set; }
        public int ChapterID { get; set; }
        public Guid CourseID { get; set; }
        public string FileID { get; set; }
        public string VideoID { get; set; }
        public bool IsMixQuestion { get; set; }
        [NotMapped]
        public string CreatedBy { get; set; }
        [NotMapped]
        public string ModifiedBy { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime ModifiedDate { get; set; }
    }
}
