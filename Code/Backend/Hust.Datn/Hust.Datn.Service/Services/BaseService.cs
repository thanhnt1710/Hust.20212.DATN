using Hust.Datn.Service.Attributes;
using Hust.Datn.Service.Const;
using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class BaseService<Entity> : IBaseService<Entity>
    {
        #region Declare
        protected readonly IBaseRepo<Entity> _baseRepo;
        protected readonly ServiceResult _serviceResult;
        protected readonly IFileSystemService _fileSystemService;
        public static readonly Type EntityType = typeof(Entity);
        #endregion

        #region Constructor
        public BaseService(IBaseRepo<Entity> baseRepo, IFileSystemService fileSystemService)
        {
            _baseRepo = baseRepo;
            _serviceResult = new ServiceResult() { Success = true };
            _fileSystemService = fileSystemService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy câu query dữ liệu
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        protected virtual async Task<string> GetSourceSql()
        {
            var attribute = EntityType.GetCustomAttribute<ViewAttribute>();
            string source = null;

            if(attribute != null && !string.IsNullOrWhiteSpace(attribute.Paging))
            {
                source = await _fileSystemService.GetFileString(FileType.SqlQuery, attribute.Paging);
            }
            return source;
        }

        public virtual async Task<IEnumerable<Entity>> GetAll() {
            var source = await this.GetSourceSql();
            return await _baseRepo.GetAll(source);
        }

        public virtual async Task<Entity> GetById(string entityId) {
            return await _baseRepo.GetById(entityId);
        }

        public virtual async Task<ServiceResult> Add(Entity entity) {
            return await _baseRepo.Add(entity);
        }

        public virtual async Task<ServiceResult> Update(Entity entity) {
            return await _baseRepo.Update(entity);
        }

        public virtual async Task<ServiceResult> Delete(List<Entity> entities) {
            return await _baseRepo.Delete(entities);
        }
        #endregion

    }
}
