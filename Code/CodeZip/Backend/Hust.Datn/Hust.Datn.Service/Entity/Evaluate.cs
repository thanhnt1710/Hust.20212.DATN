using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Evaluate
    {
        public int EvaluateID { get; set; }
        public Guid CourseID { get; set; }
        public Guid UserID { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        public string EvaluateContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public string CreatedDateStr { get; set; }
    }
}
