using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Attributes
{
    public class ViewAttribute: Attribute
    {
        public string Paging { get; set; }

        public string Execute { get; set; }
    }
}
