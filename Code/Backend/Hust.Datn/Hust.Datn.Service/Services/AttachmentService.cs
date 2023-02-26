using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<FileStreamResult> ViewAttachment(string fileKey)
        {

            var result = new FileStreamResult(new MemoryStream(), "application/pdf");
            var extension = Path.GetExtension(fileKey);
            var root = Path.Combine(Directory.GetCurrentDirectory(), @"..");
            var folderUrl = Path.Combine(root, "Uploads");

            string filePath = Path.Combine(folderUrl, fileKey);
            if (File.Exists(filePath))
            {
                byte[] fileByte = await File.ReadAllBytesAsync(filePath);
                Stream fileStream = new MemoryStream(fileByte);
                result = new FileStreamResult(fileStream, GetContentType(extension));
                result.EnableRangeProcessing = true;
            }

            return result;
        }

        public string GetContentType(string extension)
        {
            var contentType = "application/pdf";
            switch (extension)
            {
                case ".mp4":
                    contentType = "video/mp4";
                    break;
                case ".mp3":
                    contentType = "audio/mpeg";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".doc":
                    contentType = "application/msword";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".pptx":
                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    break;
                case ".ppt":
                    contentType = "application/vnd.ms-powerpoint";
                    break;
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
            }
            return contentType;
        }
        #endregion
    }
}
