using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    public class CategoryController: BaseController<Category>
    {
        protected readonly IBaseService<Category> _baseService;

        public CategoryController(IBaseService<Category> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
