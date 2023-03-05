using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class User
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLearn { get; set; } = false;
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
