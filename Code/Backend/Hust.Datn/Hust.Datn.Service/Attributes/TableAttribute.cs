using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Attributes
{
    public class TableAttribute: Attribute
    {
        /// <summary>
        /// Tên bảng
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="table"></param>
        public TableAttribute(string table)
        {
            this.Table = table;
        }
    }
}
