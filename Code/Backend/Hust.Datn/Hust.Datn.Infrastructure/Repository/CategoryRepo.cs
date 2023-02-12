using Dapper;
using Hust.Datn.Service.Const;
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
    public class CategoryRepo: BaseRepo<Category>, ICategoryRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public CategoryRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }
        #endregion

        #region Methods
        public async Task<object> GetAllCategory()
        {
            var source = await _fileSystemService.GetFileString(FileType.SqlQuery, "Category_GetAllCategory.sql");

            var listCategory = await _dbConnection.QueryAsync<Category>(source);

            return listCategory;
        }
        #endregion
    }
}
