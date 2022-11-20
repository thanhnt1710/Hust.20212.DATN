using Hust.Datn.Service.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    [Table("Category")]
    [View(Paging = "Category_Paging.sql")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
    }
}
