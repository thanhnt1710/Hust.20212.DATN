using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Chapter
    {
        public int ChapterID { get; set; }
        public string ChapterName { get; set; }
        public Guid CourseID { get; set; }
        public int ChapterPrevID { get; set; }

        [NotMapped]
        public List<Lesson> Lessons { get; set; }
    }
}
