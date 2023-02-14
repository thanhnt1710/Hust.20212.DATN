using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
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
    }
}
