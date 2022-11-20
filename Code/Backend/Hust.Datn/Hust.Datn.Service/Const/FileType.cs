using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Const
{
    public enum FileType
    {
        /// <summary>
        /// Câu Select lấy dữ liệu
        /// </summary>
        SqlQuery = 1,

        /// <summary>
        /// Câu cập nhật dữ liệu
        /// </summary>
        SqlExecute = 2
    }
}
