using Hust.Datn.Service.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Services
{
    public interface IAttachmentService : IBaseService<Attachment>
    {
        Task<ServiceResult> UploadAttachment(IFormFile attachment);

        Task<FileStreamResult> ViewAttachment(string key);
    }
}
