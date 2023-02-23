using Hust.Datn.Service.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    [View(MaxID = "Course_GetMaxID.sql")]
    public class Course
    {
        public Guid CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public Guid UserID { get; set; }
        [NotMapped]
        public string AuthorName { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string SubCategoryName { get; set; }
        [NotMapped]
        public string CreatedBy { get; set; }
        [NotMapped]
        public string ModifiedBy { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public List<Chapter> Chapters { get; set; }

        [NotMapped]
        public string JsonChapters { get; set; }

        [NotMapped]
        public List<Question> Questions { get; set; }

        [NotMapped]
        public string JsonQuestions { get; set; }
    }

    public class MaxID
    {
        public Guid CourseID { get; set; }
        public int ChapterID { get; set; }
        public int LessonID { get; set; }
    }
}
