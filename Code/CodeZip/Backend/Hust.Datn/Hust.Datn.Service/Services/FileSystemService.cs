using Hust.Datn.Service.Const;
using Hust.Datn.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class FileSystemService : IFileSystemService
    {
        #region Declare

        #endregion

        #region Constructor
        public FileSystemService() { }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy đường dẫn thư mục gốc
        /// </summary>
        /// <returns></returns>
        private string GetRootPath()
        {
            string basePath = AppContext.BaseDirectory;
            string rootPath = Path.Combine(basePath, "Stores");
            return rootPath;
        }

        /// <summary>
        /// Lấy đường dẫn file
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetPath(FileType fileType, string name = null)
        {
            var fileName = string.IsNullOrEmpty(name) ? string.Empty : Path.GetFileName(name);
            var path = Path.Combine(this.GetRootPath(), fileType.ToString(), fileName);
            return path;
        }

        /// <summary>
        /// Lấy nội dung file
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> GetFileString(FileType fileType, string fileName = null)
        {
            var content = string.Empty;

            string path = this.GetPath(fileType, fileName);

            if (System.IO.File.Exists(path))
            {
                content = System.IO.File.ReadAllText(path);
            }

            return content;
        }
        #endregion
    }
}
