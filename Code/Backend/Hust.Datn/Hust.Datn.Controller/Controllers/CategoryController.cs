using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        #region Methods
        [HttpGet("list-category")]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var entities = await _baseService.GetAll();
                if (entities.Count() > 0)
                {
                    return Ok(entities);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion
    }
}
