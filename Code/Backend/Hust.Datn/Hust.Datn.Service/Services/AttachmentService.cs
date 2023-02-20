using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        public AttachmentService(IAttachmentRepo attachmentRepo, IFileSystemService fileSystemService, IWebHostEnvironment environment, IConfiguration configuration) : base(attachmentRepo, fileSystemService, configuration)
        {
            _attachmentRepo = attachmentRepo;
            _hostingEnvironment = environment;
        }
        #endregion

        #region Methods
        public async Task<ServiceResult> UploadAttachment(IFormFile attachment)
        {
            var result = new ServiceResult();

            var root = Path.Combine(Directory.GetCurrentDirectory(), @"..");
            var folderUrl = Path.Combine(root, "Uploads");
            if (!Directory.Exists(folderUrl))
            {
                Directory.CreateDirectory(folderUrl);
            }

            // Tạo fileKey
            var fileGuid = Guid.NewGuid().ToString();
            // Lấy phần mở rộng
            var extension = Path.GetExtension(attachment.FileName);
            var fileKey = $"{fileGuid}{extension}";

            string filePath = Path.Combine(folderUrl, fileKey);
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

        public async Task<Stream> ViewAttachment(string fileKey)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), @"..");
            var folderUrl = Path.Combine(root, "Uploads");

            string filePath = Path.Combine(folderUrl, fileKey);

            string[] a = File.ReadAllLines(filePath);


        }
        #endregion
    }
}
