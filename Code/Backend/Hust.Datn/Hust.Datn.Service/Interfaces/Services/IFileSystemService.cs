using Hust.Datn.Service.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces
{
    public interface IFileSystemService
    {
        Task<string> GetFileString(FileType fileType, string fileName = null);
    }
}
