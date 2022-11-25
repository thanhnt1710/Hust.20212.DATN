using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<Entity> : ControllerBase
    {
        #region Declare
        IBaseService<Entity> _baseService;
        public ServiceResult _serviceResult;

        public BaseController(IBaseService<Entity> baseService)
        {
            _baseService = baseService;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Methods

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] string Id)
        {
            try
            {
                var entity = await _baseService.GetById(Id);
                if (entity != null)
                {
                    return Ok(entity);
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Entity entity)
        {
            try
            {
                var serviceResult = await _baseService.Add(entity);
                return Ok(serviceResult);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Entity entity)
        {
            try
            {
                var serviceResult = await _baseService.Update(entity);

                return Ok(serviceResult);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] List<Entity> parameter)
        {
            try
            {
                var serviceResult = await _baseService.Delete(parameter);

                return Ok(serviceResult);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        #endregion

        #region Other
        /// <summary>
        /// Trả về dữ liệu lỗi 500
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected IActionResult HandleException(Exception e)
        {
            _serviceResult.Success = false;
            _serviceResult.DevMsg = e.Message;
            return StatusCode(500, _serviceResult);
        }
        #endregion
    }
}
