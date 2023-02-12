using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class ServiceResult
    {
        /// <summary>
        /// Thành công hay không
        /// </summary>
        public bool Success { get; set; } = true;

        public string DevMsg { get; set; }

        public object Data { get; set; }
    }
}
