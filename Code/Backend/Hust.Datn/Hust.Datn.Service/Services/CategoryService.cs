using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class CategoryService: BaseService<Category>, ICategoryService
    {
        #region Declare
        protected readonly ICategoryRepo _categoryRepo;
        #endregion

        #region Constructor
        public CategoryService(ICategoryRepo categoryRepo, IFileSystemService fileSystemService) : base(categoryRepo, fileSystemService)
        {
            _categoryRepo = categoryRepo;
        }
        #endregion

        #region Methods
        public async Task<ServiceResult> GetAllCategory()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = await _categoryRepo.GetAllCategory();
            return serviceResult;
        }
        #endregion
    }
}
