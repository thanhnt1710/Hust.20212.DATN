using Hust.Datn.Service.Entity;
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
        public CategoryRepo(IConfiguration configuration) : base(configuration) { }
        #endregion

        #region Methods
        #endregion
    }
}
