using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class AttachmentService : BaseService<Attachment>, IAttachmentService
    {
        #region Declare
        private IWebHostEnvironment _hostingEnvironment;
        protected readonly IAttachmentRepo _attachmentRepo;
        #endregion

        #region Constructor
        public AttachmentService(IAttachmentRepo attachmentRepo, IFileSystemService fileSystemService, IWebHostEnvironment environment) : base(attachmentRepo, fileSystemService)
        {
            _attachmentRepo = attachmentRepo;
            _hostingEnvironment = environment;
        }
        #endregion

        #region Methods
        public async Task<ServiceResult> UploadAttachment(IFormFile attachment)
        {
            var result = new ServiceResult();

            var fileKey = Guid.NewGuid().ToString();
            string uploads = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), @".."), "Uploads");

            // Kiểm tra tồn tại thư mục (chưa có -> tạo)
            // Thêm đuôi (phân mở rộng) vào filekey

            string filePath = Path.Combine(uploads, attachment.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await attachment.CopyToAsync(fileStream);
            }

            if (File.Exists(filePath))
            {
                result.Success = true;
                result.Data = fileKey;
            }
            else
            {
                result.Success = false;
            }

            return result;
        }
        #endregion
    }
}
