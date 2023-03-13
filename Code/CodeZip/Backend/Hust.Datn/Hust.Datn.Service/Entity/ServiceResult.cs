using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class ServiceResult
    {
        public bool Success { get; set; } = true;

        public string DevMsg { get; set; }

        public string UserMsg { get; set; }

        public object Data { get; set; }
    }
}
