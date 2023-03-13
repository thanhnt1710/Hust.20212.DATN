using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Infrastructure.Repository
{
    public class AttachmentRepo : BaseRepo<Attachment>, IAttachmentRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public AttachmentRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }
        #endregion

        #region Methods
        #endregion
    }
}
