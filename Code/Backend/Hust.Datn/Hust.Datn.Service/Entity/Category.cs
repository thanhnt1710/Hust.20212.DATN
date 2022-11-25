using Hust.Datn.Service.Attributes;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hust.Datn.Service.Entity
{
    [Attributes.Table("Category")]
    [View(Paging = "Category_Paging.sql")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [NotMapped]
        public List<SubCategory> SubCategories { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
