using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Attachment
    {
        public int AttachmentID { get; set; }

        public string AttachmentName { get; set; }

        public Guid AttachmentKey { get; set; }

        public string AttachmentUrl { get; set; }
    }
}
