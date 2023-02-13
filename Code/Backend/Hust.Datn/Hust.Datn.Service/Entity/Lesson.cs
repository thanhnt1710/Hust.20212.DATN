using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public string LessonName { get; set; }
        public int LessonPrevID { get; set; }

        public int ChapterID { get; set; }
        public int CourseID { get; set; }
        public string FileID { get; set; }
        public string VideoID { get; set; }
        public bool IsMixQuestion { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
