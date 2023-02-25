using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    [Authorize]
    public class CourseController : BaseController<Course>
    {
        protected readonly ICourseService _courseService;

        public CourseController(ICourseService courseService) : base(courseService)
        {
            _courseService = courseService;
        }

        #region Methods
        [HttpPost("save-course")]
        public async Task<IActionResult> SaveCourse(Course course)
        {
            try
            {
                var result = await _courseService.SaveCourse(course);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("remove-course/{id}")]
        public async Task<IActionResult> RemoveCourse(Guid id)
        {
            try
            {
                var result = await _courseService.RemoveCourse(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Lấy ID lớn nhất 
        /// </summary>
        /// <returns></returns>
        [HttpPost("max-id")]
        public async Task<IActionResult> GetMaxID()
        {
            try
            {
                var result = await _courseService.GetMaxID();

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Lấy danh sách khóa học theo filter
        /// </summary>
        /// <returns></returns>
        [HttpPost("get-list-course")]
        public async Task<IActionResult> GetListCourse(ParamGetCourse param)
        {
            try
            {
                var result = await _courseService.GetListCourse(param);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion
    }
}
